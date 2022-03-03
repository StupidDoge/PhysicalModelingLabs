using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayControl : MonoBehaviour
{
    [SerializeField] private float _angle;
    [SerializeField] private MovingObject _movingObject;

    private Ray _ray;
    private RaycastHit _hit;

    public float Angle => _angle;

    void Start()
    {
        transform.Rotate(Quaternion.identity.x, Quaternion.identity.y, _angle);
    }

    void Update()
    {
        //_ray = new Ray(transform.position, -(transform.position - _movingObject.transform.position));
        _ray = new Ray(transform.position, transform.right * 100);

        Physics.Raycast(_ray);
        Debug.DrawRay(transform.position, transform.right * 100, Color.yellow);

        // 1st
        //_movingObject.Move(transform.right * Mathf.Abs(_angle));

        if (Physics.Raycast(_ray, out _hit))
        {
           Debug.Log(_hit.collider.gameObject.name + " " + _angle);
        }
    }

    public void ChangeAngle(float value, bool enter)
    {
        transform.Rotate(Quaternion.identity.x, Quaternion.identity.y, -_angle);
        if (enter)
            _angle *= value;
        else
            _angle /= value;
        transform.Rotate(Quaternion.identity.x, Quaternion.identity.y, _angle);
    }
}
