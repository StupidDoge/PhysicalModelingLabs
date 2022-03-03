using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _angle;
    [SerializeField] private GameObject _raycastPoint;

    private RayControl _rayControl;
    private Rigidbody _rb;
    private float _previousRefractiveIndex;

    public float Speed => _speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rayControl = _raycastPoint.GetComponent<RayControl>();
    }

    void FixedUpdate() // 2nd
    {
        Move();
    }

    public void Move(Vector3 endPosition) // 1st var
    {
        //transform.position = Vector3.MoveTowards(transform.position, transform.right, _speed * Time.deltaTime);
        _rb.velocity = endPosition * _speed * Time.deltaTime;
    }

    public void Move() // 2nd var
    {
        transform.Translate(VectorFromAngle(_angle) * _speed * Time.deltaTime);
        Debug.Log(_angle);
    }

    Vector3 VectorFromAngle(float theta) // 2nd
    {
        float radians = Mathf.Deg2Rad * theta;
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MaterialParams obstacle))
        {
            _rayControl.ChangeAngle(obstacle.RefractiveIndex, true);
            _previousRefractiveIndex = obstacle.RefractiveIndex;
            _angle *= obstacle.RefractiveIndex;
        }
    }*/

    /*private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out MaterialParams obstacle))
        {
            _rayControl.ChangeAngle(_previousRefractiveIndex, false);
            _angle /= obstacle.RefractiveIndex;
        }
    }*/
}
