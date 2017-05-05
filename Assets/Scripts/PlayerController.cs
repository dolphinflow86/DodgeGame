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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("cndehf!!!!!!!!!");
        Destroy(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("cndehf!!!!!!!!!");
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("cndehf!!!!!!!!!");
        Destroy(other.gameObject);
    }
}