using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private SpeedKeeper _speedKeeper;
    [SerializeField] private float _speedCoefficient;
    [SerializeField] private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speedKeeper.Speed * _speedCoefficient * Time.deltaTime);
    }
}
