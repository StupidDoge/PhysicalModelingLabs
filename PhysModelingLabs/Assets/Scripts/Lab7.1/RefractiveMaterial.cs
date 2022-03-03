using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefractiveMaterial : MonoBehaviour
{
    private enum Type // тип материала 
    {
        LiF,
        CTK9, 
        Diamond, 
        Ethanol
    }

    [SerializeField] private Type _type;
    [SerializeField] private float _size;

    private float _refractiveIndex;

    public float Index => _refractiveIndex;

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, _size, transform.localScale.z);

        switch (_type) // коэффициенты преломления
        {
            case Type.LiF:
                _refractiveIndex = 1.392f;
                break;

            case Type.CTK9:
                _refractiveIndex = 1.7424f;
                break;

            case Type.Diamond:
                _refractiveIndex = 2.417f;
                break;

            case Type.Ethanol:
                _refractiveIndex = 1.3612f;
                break;
        }
    }
}
