using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : ButtonBehaviour
{
    protected override void OnClick()
    {
        IJunior.TypedScenes.Game.Load();
    }
}
