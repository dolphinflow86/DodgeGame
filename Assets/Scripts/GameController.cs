using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // State Variables
    [System.Serializable]
    public class StageInfo
    {
        public float rateOfSpawn;
        public float enemySpawnRatio;
        public float badMissileSpeed;
        public float goodMissileSpeed;
    }

    public StageInfo[] stageInfo;

    public bool showCursor;
    private int currentStage;
    private float timeRecord;
    private static GameController instance;

    public static GameController GetInstance()
    {
        if(null == instance)
        {
            instance = GameObject.FindObjectOfType<GameController>();
            if (null == instance)
            {
                Debug.LogError("Failed to create GameController instance.");
            }
        }

        return (instance);
    }

	void Start ()
    {
        timeRecord = 0.0f;
        currentStage = 0;
    }

    void Update ()
    {
        // time setting
        timeRecord += Time.deltaTime;
        if(showCursor)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

    }

    public float GetTime()
    {
        return (timeRecord);
    }

    public StageInfo GetCurrentStageInfo()
    {
        return (stageInfo[currentStage]);
    }
}
