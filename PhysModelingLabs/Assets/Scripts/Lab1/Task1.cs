using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _movement;
    [SerializeField] private float _speed;
    private float _time = 0.0f, _distance = 0.0f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Output", 0f, 2f); // вывод инфы каждые 2 секунды
    }

    void FixedUpdate()
    {
        _movement = new Vector3(0, 0, 1); 
        _rigidbody.position = _rigidbody.position + _movement * _speed * Time.deltaTime;
        _distance += Time.deltaTime * Mathf.Abs(_speed);
        _time += Time.fixedDeltaTime;
    }

    private void Output()
    {
        Debug.Log("Object speed = " + _speed + ", time = " + (int)_time + ", distance = " + Mathf.Round(_distance));
    }
}
