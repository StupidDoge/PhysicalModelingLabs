using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1Lab5 : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _height;

    private float _x;
    private float _y;
    private float _time;
    private float _path;
    private bool _flag = true;

    void Start()
    {
        transform.position = new Vector3(0, _height, 0);
    }

    void FixedUpdate()
    {
        _time += Time.deltaTime;
        if (_flag)
        {
            _path += _speed * Time.deltaTime;
            _x = _speed * _time;
            _y = _height - (9.8f * _time * _time / 2);
            transform.position = new Vector3(_x, _y, 0);
            Debug.Log("time = " + _time + " path = " + _path);
        }
        if (transform.position.y <= 0)
            _flag = false;
    }
}
