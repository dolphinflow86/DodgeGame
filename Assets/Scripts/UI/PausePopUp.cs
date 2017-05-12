using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePopUp : UIScreen {

    void OnEnable()
    {
        GameController.GetInstance().showCursor = true;
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.instance.Hide();
        }
    }

    public void OnResumeButton()
    {
        ScreenManager.instance.Hide();
    }

    public void OnQuitButton()
    {
        //Hide the pausepopup
        ScreenManager.instance.Hide();

        //Hide the gamescreen
        ScreenManager.instance.Hide();

        SceneManager.UnloadSceneAsync(1);
    }
}
