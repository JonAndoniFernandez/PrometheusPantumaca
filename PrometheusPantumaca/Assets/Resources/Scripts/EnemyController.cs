using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Camera cam;
    Vector3 StartPosition;
    public NavMeshAgent Agent;

    public bool pursuit = false;

    public PlayerController playerController;
    public GameObject enemyBlink;

    public Animator enemyAnim;
    public Transform spriteEnemy;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartPosition = transform.position;
        spriteEnemy = transform.GetChild(0);


    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.grabbingBonfire && !playerController.GetZoneSecure())
        {
            enemyAnim.SetBool("enemyPursuit", true);
            enemyBlink.active = true;
            Agent.SetDestination(playerController.transform.position);
            //Rotar enemigo cuando se activa
            Quaternion theRotation = transform.localRotation;
            theRotation.z *= -128;
            transform.localRotation = theRotation;

            if (transform.eulerAngles.z > 180)
                spriteEnemy.GetComponent<SpriteRenderer>().flipX = true;

            else if (transform.eulerAngles.z < 180)
                spriteEnemy.GetComponent<SpriteRenderer>().flipX = false;
        }

        else
        {
            Quaternion theRotation = transform.localRotation;
            theRotation.z *= -128;
            transform.localRotation = theRotation;

            enemyBlink.active = false;
            Agent.SetDestination(StartPosition);

            if (transform.eulerAngles.z > 180)
                spriteEnemy.GetComponent<SpriteRenderer>().flipX = true;

            else if (transform.eulerAngles.z < 180)
                spriteEnemy.GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(playerController.grabbingBonfire && !playerController.GetZoneSecure())
            {
                GameOver gameOver = FindObjectOfType<GameOver>();
                gameOver.PlayerGameOver();
            }
        }
    }
}
