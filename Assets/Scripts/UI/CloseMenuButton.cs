using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenuButton : ButtonBehaviour
{
    [SerializeField] private GameObject _menu;

    protected override void OnClick()
    {
        if (_menu != null)
            _menu.SetActive(false);
    }
}
