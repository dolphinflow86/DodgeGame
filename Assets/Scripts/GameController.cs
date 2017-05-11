using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [System.Serializable]
    public class StageInfo
    {
        public float rateOfSpawn;
        public float enemySpawnRatio;
        public float badMissileSpeed;
        public float goodMissileSpeed;
        public float stageDurationSecond;
    }

    public class ScoreInfo
    {
        public string name;
        public int score;

        public ScoreInfo(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public StageInfo[] stageInfo;
    List<ScoreInfo> scoreInfoList;
    public bool showCursor;
    public int timeScore;
    public Text[] highScoreTextUI;
    public GameObject highObj;

    private int currentStage;
    private float timeRecord;
    private bool isSpawn;
    private int totalScore;
    private float currentTime;
    private float prevTime;
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
        ResetStage();
    }

    void Update ()
    {
        RecordTIme();
        RecordScore();

        if(showCursor)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

        // stage check
        if((currentStage < (stageInfo.Length - 1)) && (stageInfo[currentStage].stageDurationSecond <= timeRecord))
        {
            SetNextStage();
        }
    }
    
    public void ResetStage()
    {
        timeRecord = 0.0f;
        currentStage = 0;
        isSpawn = true;
        totalScore = 0;
        currentTime = 0.0f;
        prevTime = 0.0f;
    }

    private void RecordTIme()
    {
        // time setting
        if (FindObjectOfType<GameScreen>() != null && FindObjectOfType<GameScreen>().enabled)
        {
            timeRecord += Time.deltaTime;
            currentTime = timeRecord;
        }
    }

    private void RecordScore()
    {
        if(1.0f < (currentTime - prevTime))
        {
            totalScore += timeScore;
            prevTime = currentTime;
            //Debug.Log("TotalScore : " + totalScore);
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
        currentTime = currentTime - prevTime;
        prevTime = 0.0f;
        ++currentStage;
    }

    public void SetSpawn(bool isSpawn)
    {
        this.isSpawn = isSpawn;
    }
      
    public bool IsSpawn()
    {
        return (isSpawn);
    }

    public void AddScore(int score)
    {
        totalScore += score;
    }

    public void SaveHighScore(string playerName)
    {
        scoreInfoList.Add(new ScoreInfo(playerName, totalScore));
        scoreInfoList.Sort((s1, s2) => s1.score.CompareTo(s2.score));

        // convert a ScoreInfo to the one string
        string scoreString = "";
        foreach (ScoreInfo obj in scoreInfoList)
        {
            scoreString += obj.name + "," + obj.score + "|";
        }

        PlayerPrefs.SetString("HighScore", scoreString);
    }

    public void LoadHighScore()
    {
        if (null == scoreInfoList)
        {
            scoreInfoList = new List<ScoreInfo>();
        }

        string scoreString = PlayerPrefs.GetString("HighScore");

        // parse high score string
        string[] scoreList = scoreString.Split('|');
        foreach (string str in scoreList)
        {
            if(2 != str.Length)
            {
                break;
            }

            string[] detailInfo = str.Split(',');
            scoreInfoList.Add(new ScoreInfo(detailInfo[0], int.Parse(detailInfo[1])));
        }

        for(int ii = 0; ii < scoreInfoList.Count; ++ii)
        {
            highScoreTextUI[ii].text = (ii + 1).ToString() + "." + scoreInfoList[ii].name + " " + scoreInfoList[ii].score.ToString();
        }
    }
}