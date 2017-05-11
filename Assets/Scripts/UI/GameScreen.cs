using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : UIScreen {

    private void OnEnable()
    {
        
        GameController.GetInstance().showCursor = false;
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.instance.Show(typeof(PausePopUp));
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ScreenManager.instance.Show(typeof(GameoverPopUp));
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            ScreenManager.instance.Show(typeof(HighscorePopup));
            
        }

        if(FindObjectOfType<PlayerController>() != null && FindObjectOfType<HPManager>().playerHPLevel <= 0)
        {
            ScreenManager.instance.Show(typeof(GameoverPopUp));
        }

    }
    
}
