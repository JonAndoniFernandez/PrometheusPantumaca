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

    private Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartPosition = transform.position;
        //enemyAnim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.grabbingBonfire && !playerController.GetZoneSecure())
        {
            // enemyAnim.SetBool("enemyPursuit", true);
            enemyBlink.active = true;
            Agent.SetDestination(playerController.transform.position);
        }

        else
        {
            enemyBlink.active = false;
            Agent.SetDestination(StartPosition);
        }

    }
}
