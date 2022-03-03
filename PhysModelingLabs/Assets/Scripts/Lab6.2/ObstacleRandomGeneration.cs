using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomGeneration : MonoBehaviour
{
    private const float MAX_X = 6;
    private const float MIN_X = -6;
    private const float MAX_Y = 5;
    private const float MIN_Y = -3;

    private float _randomX;
    private float _randomY;

    [SerializeField] private int _obstacleCount;

    void Start()
    {
        for (int i = 0; i < _obstacleCount; i++)
            Spawn();
    }

    private void Spawn()
    {
        _randomX = Random.Range(MIN_X, MAX_X);
        _randomY = Random.Range(MIN_Y, MAX_Y);
        _ = Instantiate(Resources.Load("Prefabs/Obstacle"), new Vector3(_randomX, _randomY, 0), Quaternion.identity) as GameObject;
    }
}
