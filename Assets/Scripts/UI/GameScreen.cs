using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : UIScreen {

    private void OnEnable()
    {
        GameController.GetInstance().showCursor = false;
        AudioManager.instance.PlaySound("music");
    }

    void Update ()
    {
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

        if( (FindObjectOfType<PlayerController>() != null) && (FindObjectOfType<HPManager>().playerHPLevel <= 0))
        {
            if(GameController.GetInstance().IsRanked())
            {
                ScreenManager.instance.Show(typeof(HighscorePopup));
            }
            else
            {
                ScreenManager.instance.Show(typeof(GameoverPopUp));
            }

        }
    }
}
