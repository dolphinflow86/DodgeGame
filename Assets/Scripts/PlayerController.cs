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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if (null == attacker)
        {
            return;
        }

        if (collision.gameObject.tag == "BadMissile")
        {
            attacker.AttackPlayer();
        }
        else if (collision.gameObject.tag == "GoodMissile")
        {
            attacker.FeedPlayer();
        }

        Debug.Log(playerHP);

        Destroy(collision.gameObject);
    }
}