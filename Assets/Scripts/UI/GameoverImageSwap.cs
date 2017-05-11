using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverImageSwap : MonoBehaviour {

    public Sprite originalImage;
    public Sprite tryAgainImage;
    public Sprite exitImage;

    Image img;

    // Use this for initialization
    void Start () {
        img = GetComponent<Image>();
	}
	
	public void SwapToTryAgain()
    {
        img.sprite = tryAgainImage;
    }

    public void SwapToExit()
    {
        img.sprite = exitImage;
    }

    public void SwapToOriginal()
    {
        img.sprite = originalImage;
    }
}
