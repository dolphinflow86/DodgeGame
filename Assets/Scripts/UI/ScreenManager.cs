using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScreenManager : MonoBehaviour {

  

    public static ScreenManager instance;

    private Dictionary<Type, UIScreen> screens;

    private Stack<UIScreen> stack = new Stack<UIScreen>();

    void Awake()
    {
        instance = this;

        screens = new Dictionary<Type, UIScreen>();
        
        foreach (UIScreen screen in GetComponentsInChildren<UIScreen>())
        {
            screens.Add(screen.GetType(), screen);
            screen.gameObject.SetActive(false);
           
        }
        Show(typeof(MenuScreen));

    }

    public void Show(Type uiscreenType)
    {
        AudioManager.instance.Stop();

        if(uiscreenType == typeof(HighscorePopup))
        {
            AudioManager.instance.PlaySound("highscore");
        }
        else if(uiscreenType == typeof(GameoverPopUp))
        {
            AudioManager.instance.PlaySound("gameover");
        }

        UIScreen newScreen = screens[uiscreenType];

        //We check if the stack is not empty, because it's empty at the start
        if (stack.Count != 0 && newScreen.hidePrevious)
        {
            UIScreen oldScreen = stack.Peek();//Peek() returns the top object of a Stack
            oldScreen.gameObject.SetActive(false);
        }


        newScreen.gameObject.SetActive(true);

        stack.Push(newScreen);
    }

    public void Hide()
    {
        AudioManager.instance.Stop();

        UIScreen oldScreen = stack.Pop();//Pop() returns the top object of a Stack AND removes it from the stack!
        oldScreen.gameObject.SetActive(false);

        UIScreen newScreen = stack.Peek();
        newScreen.gameObject.SetActive(true);
    }
}
