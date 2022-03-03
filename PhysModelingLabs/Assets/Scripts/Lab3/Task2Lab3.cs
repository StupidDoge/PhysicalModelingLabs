using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2Lab3 : MonoBehaviour
{
    [SerializeField] private float _t1, _t2, _t3, _a, _b, _c, _d;
    private bool _flag1 = true, _flag2 = true, _flag3 = true;
    private float _time, _pathX, _pathZ, _path, _accelerationX = 0, _accelerationY = 0, _speedZ, _speedX, _speed, _acceleration;
    private Vector3 _movement;
    private Vector3 _totalDistance, _totalSpeed, _totalAcceleration;

    void FixedUpdate()
    {
        _time += Time.deltaTime;
        _movement = new Vector3(-_speedX, 0, _speedZ);
        _speedZ += _accelerationX * Time.deltaTime;
        _speedX += _accelerationY * Time.deltaTime;

        if (!_flag1)
        {
            _accelerationX = _a + _b * (_time - _t1);
            _accelerationY = _c + _d * (_time - _t1);
        }

        transform.position += _movement * Time.deltaTime;
        _pathX += Time.deltaTime * Mathf.Abs(_speedX);
        _pathZ += Time.deltaTime * Mathf.Abs(_speedZ);
        _totalDistance = new Vector3(_pathX, 0, _pathZ);
        _path = _totalDistance.magnitude;

        _totalSpeed = new Vector3(_speedX, 0, _speedZ);
        _speed = _totalSpeed.magnitude;

        _totalAcceleration = new Vector3(_accelerationY, 0, _accelerationX);
        _acceleration = _totalAcceleration.magnitude;

        if ((int)_time == _t1 && _flag1)
            _flag1 = false;

        if ((int)_time == _t2 && _flag2)
        {
            Debug.Log("Time = " + (int)_time + ", path = " + _path);
            _flag2 = false;
        }

        if ((int)_time == _t3 && _flag3)
        {
            Debug.Log("Speed = " + _speed + ", acceleration = " + _acceleration);
            _flag3 = false;
        }
    }
}
