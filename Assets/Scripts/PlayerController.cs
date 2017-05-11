using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    void Start ()
    {

    }
	
	void Update ()
    {

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

        Destroy(collision.gameObject);
    }
}