using System.Collections;

using UnityEngine;

public class PausePopUp : UIScreen {

    public void OnCancelButton()
    {
        ScreenManager.instance.Hide();
    }

    public void OnConfirmButton()
    {
        //Hide the exitpopup
        ScreenManager.instance.Hide();

        //Hide the gamescreen
        ScreenManager.instance.Hide();
    }
}
