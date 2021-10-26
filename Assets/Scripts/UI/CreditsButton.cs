using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : ButtonBehaviour
{
    [SerializeField] private GameObject _creditsMenu;

    protected override void OnClick()
    {
        if (_creditsMenu != null)
            _creditsMenu.SetActive(true);
    }
}
