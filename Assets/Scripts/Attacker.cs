using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    public Vector2 xRange;
    public Vector2 yRange;
    public float damage;

    private PlayerController playerController;
    private GameController gameController;
    private Vector3 playerPos;
    private Vector3 dirVec;
    private float missileSpeed;
    private Rigidbody2D rigid;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameController = GameController.GetInstance();
        rigid = GetComponent<Rigidbody2D>();

        Vector3 randomRange = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 1);
        dirVec = playerController.transform.position - transform.position + randomRange;

        if ("BadMissile" == tag)
        {
            SetSpeed(gameController.GetCurrentStageInfo().badMissileSpeed);
        }
        else if ("GoodMissile" == tag)
        {
            SetSpeed(gameController.GetCurrentStageInfo().goodMissileSpeed);
        }

        rigid.velocity = dirVec.normalized * missileSpeed;
    }

    void Update()
    {
        //transform.position += dirVec.normalized * missileSpeed;
        
    }

    public void AttackPlayer()
    {
        playerController.DecreaseHP(damage);
    }

    public void FeedPlayer()
    {
        playerController.IncreaseHP(damage);
    }

    public void SetSpeed(float speed)
    {
        missileSpeed = speed;
    }
}