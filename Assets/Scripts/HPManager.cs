using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour {

    public int playerHPLevel;
    public Sprite[] sprites;
    public Sprite goodEmotion;
    public Sprite badEmotion;
    public Sprite normalEmotion;
    public float addedTime;
    
    private float timeToNormal;
    private float currentTime;
    private bool isHit;

    void Start ()
    {
        UpdateHPLevel();
        timeToNormal = 0.0f;
        currentTime = 0.0f;
        isHit = false;
    }
	
	void Update ()
    {
		if(isHit)
        {
            currentTime += Time.deltaTime;
            if(timeToNormal < currentTime)
            {
                isHit = false;
                currentTime = 0.0f;
                timeToNormal = 0.0f;
                transform.parent.GetComponent<SpriteRenderer>().sprite = normalEmotion;
            }
        }
	}

    public void IncreaseHP(int value)
    {
        if ((playerHPLevel + value) < sprites.Length)
        {
            playerHPLevel += value;
        }

        UpdateHPLevel();
        transform.parent.GetComponent<SpriteRenderer>().sprite = goodEmotion;

        isHit = true;
        timeToNormal += addedTime;
    }

    public void DecreaseHP(int value)
    {
        if (0 <= (playerHPLevel - value))
        {
            playerHPLevel -= value;
        }

        UpdateHPLevel();
        transform.parent.GetComponent<SpriteRenderer>().sprite = badEmotion;

        isHit = true;
        timeToNormal += addedTime;
    }

    public void ResetHP()
    {
        playerHPLevel = 0;
        UpdateHPLevel();
    }

    private void UpdateHPLevel()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[playerHPLevel];
    }
}