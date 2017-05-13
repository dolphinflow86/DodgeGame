using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverPopUp : UIScreen {

    

    void OnEnable()
    {
        GameController.GetInstance().showCursor = true;
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void OnYesButton()
    {        
        GameController.GetInstance().ResetStage();
        ScreenManager.instance.Hide();
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);        
    }

    public void OnNoButton()
    {
        //Hide the gameoverPopup
        ScreenManager.instance.Hide();
        
        //Hide the gamescreen
        ScreenManager.instance.Hide();

        SceneManager.UnloadSceneAsync(1);
        
    }
}
