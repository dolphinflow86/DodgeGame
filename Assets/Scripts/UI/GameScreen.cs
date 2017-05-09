using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : UIScreen {

    private void OnEnable()
    {
        GameController.GetInstance().showCursor = false;
    }

    private void OnDisable()
    {
        GameController.GetInstance().showCursor = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.instance.Show(typeof(PausePopUp));
        }
    }
}
