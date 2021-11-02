using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CookieCollider : MonoBehaviour
{
    public event UnityAction CoinPicked;
    public event UnityAction Smashed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            CoinPicked?.Invoke();
            coin.gameObject.SetActive(false);
        }

        if (collision.TryGetComponent(out Cup cup))
        {
            Smashed?.Invoke();
        }
    }
}
