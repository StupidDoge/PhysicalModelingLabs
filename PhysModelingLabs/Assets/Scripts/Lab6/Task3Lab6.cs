using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3Lab6 : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb1;
    [SerializeField] private Rigidbody _rb2;
    [SerializeField] private float _mass1;
    [SerializeField] private float _mass2;
    [SerializeField] private float _v1;
    [SerializeField] private float _v2;

    private float _u1;
    private float _u2;
    private bool _hitFlag = false;

    void Start()
    {
        _rb1.mass = _mass1;
        _rb2.mass = _mass2;
        _rb1.transform.position = new Vector3(0, 0, 0);
        _rb2.transform.position = new Vector3(10, 0, 0);
    }

    void FixedUpdate()
    {
        if (_hitFlag)
        {
            _u1 = (_v1 * (_mass1 - _mass2) + 2 * _mass2 * _v2) / (_mass1 + _mass2); // скорость первого шарика после удара
            _u2 = (_v2 * (_mass1 - _mass2) + 2 * _mass1 * _v1) / (_mass1 + _mass2); // скорость второго шарика после удара
            _rb1.velocity = new Vector3(_u1, 0, 0);
            _rb2.velocity = new Vector3(_u2, 0, 0);
        }
        if (!_hitFlag)
        {
            _rb1.velocity = new Vector3(_v1, 0, 0);
            _rb2.velocity = new Vector3(_v2, 0, 0);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        _hitFlag = true;
    }
}
