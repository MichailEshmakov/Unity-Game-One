using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedCoefficient;
    [SerializeField] private Vector2 _direction;

    private float _globalSpeed = 1;

    private void Update()
    {
        transform.Translate(_direction * _globalSpeed * _speedCoefficient * Time.deltaTime);
    }

    public void Init(float globalSpeed)
    {
        _globalSpeed = globalSpeed;
    }
}
