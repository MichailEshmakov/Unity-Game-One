using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnableObject : MonoBehaviour
{
    [SerializeField] private float _leftOffset;
    [SerializeField] private float _rightOffset;

    public float LeftOffset => _leftOffset;
    public float RightOffset => _rightOffset;
}
