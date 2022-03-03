using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2Lab6 : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb1;
    [SerializeField] private Rigidbody _rb2;
    [SerializeField] private float _mass1;
    [SerializeField] private float _mass2;
    [SerializeField] private float _v1;

    private float _u1;
    private float _u2;
    private float _x; // смещение по x
    private float _z; // смещение по y (в трехмерной системе координат по z)
    private Vector3 _direction1; //направление движения 1 шарика
    private Vector3 _direction2; //направление движения 2 шарика

    void Start()
    {
        _rb1.mass = _mass1;
        _rb2.mass = _mass2;
        _rb1.transform.position = new Vector3(0, 0, 0.5f);
        _rb2.transform.position = new Vector3(10, 0, 0);

        _rb1.freezeRotation = true;
        _rb2.freezeRotation = true;
        _rb1.velocity = new Vector3(_v1, 0, 0); // скорость шара до столкновения 
    }

    public void OnCollisionEnter(Collision other) // просчёт идёт при столкновении шариков
    {
        _x = _rb2.position.x - _rb1.position.x; // всегда больше 0
        _z = _rb1.position.z - _rb2.position.z; // больше или меньше 0
        _u1 = (_v1 - _u2 * _z * _z) / _x; // скорость первого шарика после удара
        _u2 = _v1 * _z; // скорость второго шарика после удара

        if (_z > 0) // если смещение положительно
        {
            _direction1 = new Vector3(_z, 0, _x);
            _direction2 = new Vector3(_x, 0, -_z);
        }
        else // иначе
        {
            _direction1 = new Vector3(_x, 0, _z);
            _direction2 = new Vector3(_z, 0, -_x);
        }

        _rb1.velocity = _direction1 * _u1;
        _rb2.velocity = _direction2 * _u2;
    }

}
