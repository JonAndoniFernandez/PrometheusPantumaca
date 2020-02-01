using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesBlinkController : MonoBehaviour
{
    //def variables
    public GameObject EyesPrefab;
    public GameObject[] enemies;
    public string EnemyTag = "Enemy";
    public float blinkTime = 1.0f;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
    }

    // Update is called once per frame
    void Update()
    {
        //if el jugador ha cogido la llama
        time += Time.deltaTime;

        if(time >= blinkTime)
        {
            time = 0.0f;
            for (int i = 0; i < enemies.Length; i++)
            {
                Instantiate(EyesPrefab, enemies[i].transform.position, Quaternion.identity);
            }
        }
    }
}
