using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : UIScreen {

    private void OnEnable()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.instance.Show(typeof(PausePopUp));
        }
    }
}
