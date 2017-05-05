using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    public float missileSpeed;
    private Vector3 playerPos;
    private Vector3 dirVec;
	void Start ()
    {
        playerPos = FindObjectOfType<Mover>().transform.position;

        Vector3 randomRange = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 1);

        dirVec = playerPos - transform.position + randomRange;
        
    }
	
	void Update ()
    {
        transform.position += dirVec.normalized * missileSpeed;
	}
}