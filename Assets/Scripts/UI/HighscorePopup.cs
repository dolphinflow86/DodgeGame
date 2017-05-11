using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscorePopup : UIScreen {

    void OnEnable()
    {
        GameController.GetInstance().showCursor = true;
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void GetInput(string nameInput)
    {
        Debug.Log(nameInput);
        GameController.GetInstance().SaveHighScore(nameInput);
        ScreenManager.instance.Hide();
        ScreenManager.instance.Show(typeof(GameoverPopUp));
    }

    public void ConfirmButton()
    {
        InputField input = GetComponent<InputField>();
        GameController.GetInstance().SaveHighScore(input.text);
        Debug.Log(input.text);
        ScreenManager.instance.Hide();
        ScreenManager.instance.Show(typeof(GameoverPopUp));
    }
}