using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1Lab2 : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private float _angle, _time = 0f, _turnovers, _angularVelocity;
    [SerializeField] private float _frequency;
    [SerializeField] private float _radius;
    private Vector3 _distance;

    void Start()
    {
        _distance = new Vector3(_radius, 0, _radius);
        transform.position = _target.transform.position + _distance;
        InvokeRepeating("Output", 0f, 1f);
    }

    void FixedUpdate()
    {
        _time += Time.deltaTime;
        _angle = _frequency * 360;
        _angularVelocity = Mathf.PI * 2 * _frequency;
        transform.RotateAround(_target.transform.position, Vector3.up, _angle * Time.deltaTime);
        _turnovers += Time.deltaTime * _frequency;
    }

    private void Output() // в выводе округлим количество оборотов до двух знаков после запятой
    {
        Debug.Log("t = " + (int)_time + ", turnovers = " + Mathf.Round(_turnovers * 100f) / 100f + ", angular velocity = " + _angularVelocity); 
    }
}
