using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : UIScreen {

    private void OnEnable()
    {
        GameController.GetInstance().showCursor = true;
        GameController.GetInstance().LoadHighScore();
    }



    public void OnStartGameButton()
    {
        GameController.GetInstance().ResetStage();
        ScreenManager.instance.Show(typeof(GameScreen));
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }
}
