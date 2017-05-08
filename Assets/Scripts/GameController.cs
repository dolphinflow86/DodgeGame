using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float enemySpawnRatio;
    private float timeRecord;

	void Start ()
    {
        timeRecord = 0.0f;
    }

    void Update ()
    {
        // time setting
        timeRecord += Time.deltaTime;
    }

    public float GetTime()
    {
        return (timeRecord);
    }

    public float GetEnemySpawnRatio()
    {
        return (enemySpawnRatio);
    }
}
