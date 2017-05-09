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
        public float stageDurationSecond;
    }

    public StageInfo[] stageInfo;

    public bool showCursor;
    private int currentStage;
    private float timeRecord;
    private bool isSpawn;
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
        isSpawn = true;
    }

    void Update ()
    {
        // time setting
        if(FindObjectOfType<GameScreen>() != null && FindObjectOfType<GameScreen>().enabled)
        {
            timeRecord += Time.deltaTime;
        }
        
        if(showCursor)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

        // stage check
        if((currentStage < stageInfo.Length) && (stageInfo[currentStage].stageDurationSecond <= timeRecord))
        {
            SetNextStage();
        }
    }

    public float GetTime()
    {
        return (timeRecord);
    }

    public StageInfo GetCurrentStageInfo()
    {
        if(stageInfo.Length <= currentStage)
        {
            Debug.LogError("Check currentStageIndex");
        }

        return (stageInfo[currentStage]);
    }

    public void SetNextStage()
    {
        // Reset stageInfo
        timeRecord = 0.0f;
        ++currentStage;

        // Show Stage Text
    }

    public void SetSpawn(bool isSpawn)
    {
        this.isSpawn = isSpawn;
    }
      
    public bool IsSpawn()
    {
        return (isSpawn);
    }
}
