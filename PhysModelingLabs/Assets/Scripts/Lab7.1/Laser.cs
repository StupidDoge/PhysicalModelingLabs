using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser
{
    private Vector3 _pos, _dir;
    [SerializeField] private GameObject _laserObj; // источник 
    private LineRenderer _laser; // лазер
    private List<Vector3> _laserIndices = new List<Vector3>(); // массив, содержащий каждую точку луча

    public GameObject LaserObject => _laserObj; 

    public Laser(Vector3 pos, Vector3 dir, Material material) // конструктор класса, тут создаётся луч
    {
        _laser = new LineRenderer();
        _laserObj = new GameObject();
        _laserObj.name = "Light Beam";
        _pos = pos;
        _dir = dir;

        _laser = _laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer; // Line renderer добавляется к создаваемому игровому объекту каждый раз когда создаётся луч
        _laser.startWidth = 0.05f;
        _laser.endWidth = 0.05f;
        _laser.material = material;
        _laser.startColor = Color.white;
        _laser.endColor = Color.white;

        CastRay(pos, dir, _laser); // создание луча со всеми настройками
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        _laserIndices.Add(pos); // добавляем позицию в массив точек луча
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 200, 1)) // если луч взаимодействует с чем-либо, то
        {
            CheckHit(hit, dir, laser); // проверям объект, куда попал луч
        }
        else // а иначе
        {
            _laserIndices.Add(ray.GetPoint(200));  // добавляем в массив точек координату 
            UpdateRay(); // и обновляем луч
        }
    }

    void UpdateRay() // функция пересчёта координат луча
    {
        int count = 0;
        _laser.positionCount = _laserIndices.Count;

        foreach (Vector3 idx in _laserIndices) // тут обновляем координаты
        {
            _laser.SetPosition(count, idx);
            count++;
        }
    }

    void CheckHit(RaycastHit hitinfo, Vector3 direction, LineRenderer laser) // тут контролируется поведение луча при взаимодействии с объектами
    {
        if (hitinfo.collider.gameObject.tag == "Mirror") // в зеркале луч отражается 
        {
            Vector3 pos = hitinfo.point; // начальная позиция 
            Vector3 dir = Vector3.Reflect(direction, hitinfo.normal); // направление луча - отражение 

            CastRay(pos, dir, laser); // создаём отражённый луч
        }
        else if (hitinfo.collider.gameObject.tag == "Refract" || hitinfo.collider.gameObject.tag == "Lens") // отдельное поведение для линз и преломляющих материалов
        {
            Vector3 pos = hitinfo.point; // стартовая позиция
            _laserIndices.Add(pos);

            Vector3 newpos1 = new Vector3(Mathf.Abs(direction.x) / (direction.x + 0.0001f) * 0.001f + pos.x, Mathf.Abs(direction.y) / (direction.y + 0.0001f) * 0.001f + pos.y, Mathf.Abs(direction.z) / (direction.z + 0.0001f) * 0.001f + pos.z); // для избежания ошибок точка столкновения сдигается чуть внутрь коллайдера

            float n1 = 1f; // коэффициент преломления воздуха
            float n2; // коэффициент преломления среды
            if (hitinfo.collider.gameObject.tag == "Refract") // если взаимодействие с преломляющим материалом
                n2 = hitinfo.collider.gameObject.GetComponent<RefractiveMaterial>().Index; // то индекс преломления получаем из него
            else
                n2 = 1.3f; // если линза, то просто берём такой показатель преломления 

            Vector3 norm = hitinfo.normal;
            Vector3 incident = direction;

            Vector3 refractedVector = Refract(n1, n2, norm, incident); // получаем отраженный вектор

            Ray ray1 = new Ray(newpos1, refractedVector);
            Vector3 newRayStartPos = ray1.GetPoint(1.5f);

            Ray ray2 = new Ray(newRayStartPos, -refractedVector);
            RaycastHit hit2;

            if (Physics.Raycast(ray2, out hit2, 1.5f, 1))
                _laserIndices.Add(hit2.point);

            UpdateRay(); 

            Vector3 refractedVector2 = Refract(n2, n1, -hit2.normal, refractedVector);
            CastRay(hit2.point, refractedVector2, laser);
        }
        else if (hitinfo.collider.gameObject.tag == "Finish") // для лабы 7.2
        {
            Debug.Log("Луч достиг цели");
            _laserIndices.Add(hitinfo.point);
            UpdateRay();
        }
        else // если ни с чем не сталкиваемся, то просто пускаем луч дальше
        {
            _laserIndices.Add(hitinfo.point);
            UpdateRay();
        }
    }

    Vector3 Refract(float n1, float n2, Vector3 norm, Vector3 incident) // функция преломления
    {
        incident.Normalize();

        // полученный вектор преломлённого луча
        Vector3 refractedVector = (n1 / n2 * Vector3.Cross(norm, Vector3.Cross(-norm, incident)) - norm * Mathf.Sqrt(1 - Vector3.Dot(Vector3.Cross(norm, incident) * (n1 / n2 * n1 / n2), Vector3.Cross(norm, incident)))).normalized;

        return refractedVector;
    }
}
