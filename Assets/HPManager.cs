using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour {

    public int playerHPLevel;
    public Sprite[] sprites;

    private SpriteRenderer hpImage;

    void Start ()
    {
        hpImage = GetComponent<SpriteRenderer>();
        UpdateHPLevel();
    }
	
	void Update () {
		
	}

    public void IncreaseHP(int value)
    {
        if ((playerHPLevel + value) < sprites.Length)
        {
            playerHPLevel += value;
        }
        UpdateHPLevel();
    }

    public void DecreaseHP(int value)
    {
        if (0 <= (playerHPLevel - value))
        {
            playerHPLevel -= value;
        }
        UpdateHPLevel();
    }

    public void ResetHP()
    {
        playerHPLevel = 0;
        UpdateHPLevel();
    }

    private void UpdateHPLevel()
    {
        Debug.Log("playerHPLevel : " + playerHPLevel);
        GetComponent<SpriteRenderer>().sprite = sprites[playerHPLevel];
    }
}
