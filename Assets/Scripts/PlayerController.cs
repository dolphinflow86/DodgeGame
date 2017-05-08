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
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}