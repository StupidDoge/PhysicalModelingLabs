using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2Lab5 : MonoBehaviour
{
    [SerializeField] private float _height;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _angle;
    [SerializeField] private float _t;
    
    private float _time;
    private float _x, _y;
    private float _path;
    private float _speed, _startSpeed;
    private bool _flag1 = true, _flag2 = true;

    void Start()
    {
        transform.position = new Vector3(0, _height, 0);
        _startSpeed = _acceleration * 1f;
    }

    void FixedUpdate()
    {
        _time += Time.deltaTime;

        if (_flag1 && !_flag2)
        {
            _path += _speed * Time.deltaTime; 
            _speed = _acceleration * (_time - _t);
            _x = _startSpeed * Mathf.Cos(_angle * Mathf.PI / 180) * (_time - _t);
            _y = _height + _startSpeed * Mathf.Sin(_angle * Mathf.PI / 180) * (_time - _t) - 9.8f * (_time - _t) * (_time - _t) / 2;
            transform.position = new Vector3(_x, _y, 0);
            Debug.Log("time = " + (_time - _t) + " speed sr = " + _path / (_time - _t) + "speed = " + _speed + " lenght = " + _x);
        }

        if (transform.position.y <= 0)
            _flag1 = false;

        if ((int)_time == _t)
            _flag2 = false;
    }
}
