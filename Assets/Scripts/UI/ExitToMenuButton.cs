using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitToMenuButton : ButtonBehaviour
{
    protected override void OnClick()
    {
        IJunior.TypedScenes.MainMenu.Load();
    }
}
