using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : UIScreen {

    public void OnStartGameButton()
    {
        ScreenManager.instance.Show(typeof(GameScreen));
    }
}
