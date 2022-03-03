using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4_2 : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _movement;
    [SerializeField] private float _speed, _acceleration;
    private float _time = 0.0f, _distance;

    private float _distanceX, _distanceZ; // будем отдельно считать пройденное расстояние по x и z
    private Vector3 _totalDistance;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Output", 0f, 2f); // вывод инфы каждые 2 секунды
        InvokeRepeating("IncreaseForce", 0f, 2f); // ускорение объекта каждые 2 секунды
    }

    void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
        _movement = new Vector3(-1f, 0, 1);
        _rigidbody.position = _rigidbody.position + _movement * _speed * Time.deltaTime;
        _distanceX += Time.deltaTime * Mathf.Abs(_speed) * Mathf.Abs(_movement.x);
        _distanceZ += Time.deltaTime * Mathf.Abs(_speed) * Mathf.Abs(_movement.z);
        _totalDistance = new Vector3(_distanceX, 0, _distanceZ);
        _distance = _totalDistance.magnitude; // итого объект проходит расстояние равное корню из суммы квадратов расстояний по осям x, y (всегда 0) и z
    }

    private void Output()
    {
        Debug.Log("Object speed = " + _speed + ", time = " + (int)_time + ", distance = " + Mathf.Round(_distance) + ", coordinates = " + transform.position);
    }

    private void IncreaseForce() // т.к. теперь движение равноускоренное, прибавляем к изначальной скорости объекта значение ускорения
    {
        _speed += _acceleration;
    }
}
