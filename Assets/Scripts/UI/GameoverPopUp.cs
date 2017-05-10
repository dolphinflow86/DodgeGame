using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverPopUp : UIScreen {

    public void OnYesButton()
    {
        ScreenManager.instance.Hide();
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);

    }

    public void OnConfirmButton()
    {
        //Hide the gameoverPopup
        ScreenManager.instance.Hide();
        //Hide the pausepopup
        ScreenManager.instance.Hide();

        //Hide the gamescreen
        ScreenManager.instance.Hide();
    }
}
