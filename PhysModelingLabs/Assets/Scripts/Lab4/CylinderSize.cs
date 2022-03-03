using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSize : MonoBehaviour
{
    private enum Task
    {
        task1,
        task2, 
        task3
    }

    [SerializeField] private Task _task;

    [SerializeField] private GameObject _sphere;
    private Task1Lab4 _task1;
    private Task2Lab4 _task2;
    private Task3Lab4 _task3;
    private Vector3 _scale;
    private float _radius;

    void Start()
    {
        _task1 = _sphere.GetComponent<Task1Lab4>();
        _task2 = _sphere.GetComponent<Task2Lab4>();
        _task3 = _sphere.GetComponent<Task3Lab4>();
    }

    private void Update()
    {
        switch (_task)
        {
            case Task.task1:
                _radius = _task1.GetRadius() * 2 - _sphere.transform.localScale.x;
                break;

            case Task.task2:
                _radius = _task2.GetRadius() * 2 - _sphere.transform.localScale.x;
                break;

            case Task.task3:
                _radius = _task3.GetRadius() * 2 - _sphere.transform.localScale.x;
                break;
        }

        _scale = new Vector3(_radius, 20, _radius);
        transform.localScale = _scale;
    }

}
