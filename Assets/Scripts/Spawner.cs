using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public GameObject badObject;
    public GameObject goodObject;
    

    private float enemySpawnRatio;
    private float rateOfSpawn;
    private float nextSpawn = 0;
    private GameController gameController;
    
    void Start ()
    {
        gameController = GameController.GetInstance();
        rateOfSpawn = gameController.GetCurrentStageInfo().rateOfSpawn;
        enemySpawnRatio = gameController.GetCurrentStageInfo().enemySpawnRatio;
    }
	
	void Update ()
    {
        if(gameController.IsSpawn())
        {
            SpawnMissiles();
        }
    }

    void SpawnMissiles()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + rateOfSpawn;

            // Random position within this transform
            Vector2 rndPosWithin;
            rndPosWithin = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * 0.5f);

            //Set active scene to the "Game" Scene so all the objects can be spawned in the Game Scene
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));

            Instantiate((enemySpawnRatio < Random.Range(0.0f, 10.0f)) ? goodObject : badObject, rndPosWithin, transform.rotation);
        }
    }
}
