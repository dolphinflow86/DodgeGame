using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Vector2 spawnMonsterRatio;
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
}
