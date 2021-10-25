using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : ButtonBehaviour
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}
