using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerHP;

	void Start ()
    {

    }
	
	void Update ()
    {
        //float HPScale = playerHP / 100.0f;
	}

    public void IncreaseHP(float value)
    {
        playerHP += value;
    }

    public void DecreaseHP(float value)
    {
        playerHP -= value;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Attacker attacker = col.gameObject.GetComponent<Attacker>();
        if(null == attacker)
        {
            return;
        }

        if (col.gameObject.tag == "BadMissile")
        {
            attacker.AttackPlayer();
        }
        else if(col.gameObject.tag == "GoodMissile")
        {
            attacker.FeedPlayer();
        }

        Debug.Log(playerHP);

        Destroy(col.gameObject);
    }
}