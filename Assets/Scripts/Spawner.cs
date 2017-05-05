using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject objectToSpawn;
    public float rateOfSpawn = 1;

    private float nextSpawn = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {

            nextSpawn = Time.time + rateOfSpawn;

            // Random position within this transform
            Vector2 rndPosWithin;
            rndPosWithin = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * 0.5f);
            Instantiate(objectToSpawn, rndPosWithin, transform.rotation);
        }
    }
}
