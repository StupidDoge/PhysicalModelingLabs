using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1Lab6_2 : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float _v;
    [SerializeField] private float _a;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = VectorFromAngle(_a) * _v;
    }

    Vector2 VectorFromAngle(float angle)
    {
        float radians = Mathf.Deg2Rad * angle;
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
            _rb.velocity = Vector3.zero;
    }
}
