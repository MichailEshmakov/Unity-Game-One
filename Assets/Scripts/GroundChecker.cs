using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _bottom;
    [SerializeField] private float _bottomSize;
    [SerializeField] private LayerMask _goundLayer;

    public bool IsOnGround()
    {
        return Physics2D.OverlapCircle(_bottom.position, _bottomSize, _goundLayer);
    }
}
