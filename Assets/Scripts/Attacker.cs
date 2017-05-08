using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    public float missileSpeed;
    public Vector2 xRange;
    public Vector2 yRange;
    public float damage;

    private PlayerController playerController;
    private Vector3 playerPos;
    private Vector3 dirVec;
	void Start ()
    {
        playerController = FindObjectOfType<PlayerController>();
        Vector3 randomRange = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        dirVec = playerController.transform.position - transform.position + randomRange;
    }
	
	void Update ()
    {
        transform.position += dirVec.normalized * missileSpeed;
	}

    public void AttackPlayer()
    {
        playerController.DecreaseHP(damage);
    }

    public void FeedPlayer()
    {
        playerController.IncreaseHP(damage);
    }
}