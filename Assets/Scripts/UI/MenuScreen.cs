using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : UIScreen {

    public void OnStartGameButton()
    {
        ScreenManager.instance.Show(typeof(GameScreen));
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }
}
