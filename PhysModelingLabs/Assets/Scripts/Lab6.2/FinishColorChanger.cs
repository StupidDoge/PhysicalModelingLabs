using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _renderer.material.SetColor("_Color", Color.cyan);
    }
}
