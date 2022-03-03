using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private Renderer _renderer;
    private float _time;

    void Start()
    {
        transform.localScale = new Vector3(Random.Range(1f, 2.5f), Random.Range(0.2f, 0.4f), 1);
        transform.Rotate(0, 0, Random.Range(0, 360));

        GetComponent<Rigidbody>().isKinematic = SetBoolRandomly(0.25f);

        _renderer = GetComponent<Renderer>();

        if (GetComponent<Rigidbody>().isKinematic)
            _renderer.material.SetColor("_Color", Color.cyan);
    }

    private void FixedUpdate()
    {
        _time += Time.deltaTime;
    }

    private bool SetBoolRandomly(float chance)
    {
        float randomNum = Random.Range(0.0f, 1.0f);
        if (randomNum <= chance)
            return true;
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<ObstacleScript>() && _time < 0.5f)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            _renderer.material.SetColor("_Color", Color.cyan);
        }
    }
}