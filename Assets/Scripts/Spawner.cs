using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject badObject;
    public GameObject goodObject;
    public float rateOfSpawn;

    private float enemySpawnRatio;
    private float nextSpawn = 0;
    
    void Start ()
    {
        enemySpawnRatio = FindObjectOfType<GameController>().GetEnemySpawnRatio();
    }
	
	void Update ()
    {
        
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + rateOfSpawn;

            // Random position within this transform
            Vector2 rndPosWithin;
            rndPosWithin = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * 0.5f);
            Instantiate((enemySpawnRatio < Random.Range(0.0f, 9.0f)) ? goodObject : badObject, rndPosWithin, transform.rotation);
        }
    }
}
