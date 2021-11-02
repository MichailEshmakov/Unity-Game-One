using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverer : MonoBehaviour
{
    [SerializeField] private CookieCollider _cookieCollider;
    [SerializeField] private GameObject _restartMenu;

    private void OnEnable()
    {
        _cookieCollider.Smashed += OnCookieSmashed;
    }

    private void OnDisable()
    {
        _cookieCollider.Smashed -= OnCookieSmashed;
    }

    private void OnCookieSmashed()
    {
        OverGame();
    }

    private void OverGame()
    {
        Time.timeScale = 0;
        _restartMenu.SetActive(true);
    }
}
