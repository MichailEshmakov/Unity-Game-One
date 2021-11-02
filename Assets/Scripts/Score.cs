using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private CookieCollider cookieCollider;

    private int _value = 0;

    public int Value => _value;
    public event UnityAction Changed;

    private void OnEnable()
    {
        cookieCollider.CoinPicked += OnCoinPicked;
    }

    private void OnDisable()
    {
        cookieCollider.CoinPicked -= OnCoinPicked;
    }

    private void OnCoinPicked()
    {
        ChangeValue(1);
    }

    private void ChangeValue(int delta)
    {
        _value += delta;
        Changed?.Invoke();
    }
}
