using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieRotator : MonoBehaviour
{
    [SerializeField] private GlobalSpeed _globalSpeed;
    [SerializeField] private float _speedCoefficient;
    [SerializeField] private float _radius;

    private float _rotationSpeed;

    private void Awake()
    {
        if (_radius != 0)
        {
            float perimeter = 2 * Mathf.PI * _radius;
            _rotationSpeed = 360 * _globalSpeed.Value * _speedCoefficient / perimeter;
        }

    }

    private void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(_rotationSpeed * Time.deltaTime, -Vector3.forward);
    }
}
