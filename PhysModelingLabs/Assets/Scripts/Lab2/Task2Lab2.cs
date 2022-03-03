using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2Lab2 : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private float _angle, _time = 0f, _path, _turnovers, _angleSum;
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
        _turnovers += Time.deltaTime * _frequency;
        _path = 2 * Mathf.PI * _radius * _turnovers;
        transform.RotateAround(_target.transform.position, Vector3.up, _angle * Time.deltaTime);
    }

    private void Output()
    {
        Debug.Log("t = " + (int)_time + ", path = " + _path + ", rotation angle = " + _angleSum);

        _angleSum += _angle;
    }
}
