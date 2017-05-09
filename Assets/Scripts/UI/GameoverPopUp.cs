using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverPopUp : UIScreen {

    public void OnCancelButton()
    {
        ScreenManager.instance.Hide();
    }

    public void OnConfirmButton()
    {
        //Hide the pausepopup
        ScreenManager.instance.Hide();

        //Hide the gamescreen
        ScreenManager.instance.Hide();
    }
}
