using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    public Vector2 xRange;
    public Vector2 yRange;
    public int damage;
    public int score;

    private PlayerController playerController;
    private HPManager hpManager;
    private GameController gameController;
    private Vector3 playerPos;
    private Vector3 dirVec;
    private float missileSpeed;
    private Rigidbody2D rigid;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        hpManager = FindObjectOfType<HPManager>();
        gameController = GameController.GetInstance();
        rigid = GetComponent<Rigidbody2D>();

        Vector3 randomRange = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        dirVec = playerController.transform.position - transform.position + randomRange;

        SetSpeed();

        rigid.velocity = dirVec.normalized * missileSpeed;
    }

    void Update()
    {
        SetSpeed();
    }

    public void AttackPlayer()
    {
        //hpManager.DecreaseHP(damage);
        gameController.AddScore(score);
    }

    public void FeedPlayer()
    {
        hpManager.IncreaseHP(damage);
        gameController.AddScore(score);
    }

    public void SetSpeed()
    {
        if ("BadMissile" == tag)
        {
            missileSpeed = gameController.GetCurrentStageInfo().badMissileSpeed;
        }
        else if ("GoodMissile" == tag)
        {
            missileSpeed = gameController.GetCurrentStageInfo().goodMissileSpeed;
        }
    }
}