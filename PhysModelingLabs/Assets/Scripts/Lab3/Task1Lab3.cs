using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1Lab3 : MonoBehaviour
{
    [SerializeField] private float _t1, _t2, _t3, _a, _b;
    private bool _flag1 = true, _flag2 = true, _flag3 = true;
    private float _time, _path, _acceleration = 0, _speed;
    private Vector3 _movement;

    void FixedUpdate()
    {
        _time += Time.deltaTime;
        _movement = new Vector3(0, 0, _speed);
        _speed += _acceleration * Time.deltaTime;
        if (!_flag1)
            _acceleration = _a + _b * (_time - _t1);

        transform.position = transform.position + _movement * Time.deltaTime;
        _path += Time.deltaTime * Mathf.Abs(_speed);

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
