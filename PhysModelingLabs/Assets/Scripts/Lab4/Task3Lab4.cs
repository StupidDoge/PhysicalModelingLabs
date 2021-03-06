using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3Lab4 : MonoBehaviour
{
    [SerializeField] private float _height, _speed, _t, _radius, _A, _B;
    private float _time, _distance, _frequency, _quantity, _alpha = 0, _acceleration;
    private float _x, _y, _z;
    private Vector3 _direction;
    private bool _flag1;

    public float GetRadius()
    {
        return _radius;
    }

    void Start()
    {
        transform.position = new Vector3(_radius, 0, 0);
        InvokeRepeating("Output", 0f, 1f);
    }

    void FixedUpdate()
    {
        _time += Time.deltaTime;

        if (_flag1)
        {
            _frequency = _speed / (2 * Mathf.PI * _radius);
            _acceleration = _A + _B * (_time - _t);
            _speed += _acceleration * Time.deltaTime;
            _x = _radius * Mathf.Cos(_alpha * Mathf.PI / 180);
            _y = _alpha * _height / 360;
            _z = _radius * Mathf.Sin(_alpha * Mathf.PI / 180);
            _direction = new Vector3(_x, _y, _z);

            transform.position = _direction;

            _quantity += _frequency * Time.deltaTime;
            _alpha = 360 * _quantity;
            _distance += _speed * Time.deltaTime;
        }

        if ((int)_time == _t && !_flag1)
            _flag1 = true;
    }

    private void Output()
    {
        Debug.Log("Time = " + (int)_time + ", distance = " + _distance + ", coordinates = " + _direction + ", a = " + _acceleration);
    }
}
