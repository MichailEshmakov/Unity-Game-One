using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private ClickZone _clickZone;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpHeight;

    private Rigidbody2D _rigidbody;
    private float _jumpImpulse;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _jumpImpulse = _rigidbody.mass * Mathf.Sqrt(2 * -Physics2D.gravity.y * _jumpHeight);
    }

    private void OnEnable()
    {
        _clickZone.Click += OnClick;
    }

    private void OnDisable()
    {
        _clickZone.Click -= OnClick;
    }

    private void OnClick()
    {
        TryJump();
    }

    private void TryJump()
    {
        if (_groundChecker.IsOnGround())
        {
            _rigidbody.AddForce(Vector3.up * _jumpImpulse, ForceMode2D.Impulse);
        }
    }
}
