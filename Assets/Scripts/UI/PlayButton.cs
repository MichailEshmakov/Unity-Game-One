using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : ButtonBehaviour
{
    protected override void OnClick()
    {
        Time.timeScale = 1;
        IJunior.TypedScenes.Game.Load();
    }
}
