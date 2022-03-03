using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    [SerializeField] private Material _material; // материал для визуализации луча
    private Laser _laser;

    private void Start()
    {
        StartCoroutine(FirstCast()); // создаём луч впервые 
    }

    void Update()
    {
        if (gameObject.transform.hasChanged) // функция обновления лазера будет вызываться только если координаты или угол вращения данного объекта были изменены
            UpdateLaser(); 
    }

    private void UpdateLaser()
    {
        if (_laser != null) // если лазер уже есть, то уничтожаем объект, так как нам нужен лишь один лазер
            Destroy(_laser.LaserObject);

        _laser = new Laser(gameObject.transform.position, gameObject.transform.right, _material);
    }

    IEnumerator FirstCast() 
    {
        yield return new WaitForSeconds(0.5f); // луч создаётся с небольшой задержкой, чтобы не было конфликта с другими объектами
        if (_laser != null)
            Destroy(_laser.LaserObject);
        _laser = new Laser(gameObject.transform.position, gameObject.transform.right, _material);
    }
}
