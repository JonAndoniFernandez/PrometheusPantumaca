using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    Animator anim;
    [SerializeField] bool gameOver = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(gameOver)
        {
            if (Input.GetButton("Fire1"))
            {
                anim.SetBool("RestartLevel", true);
            }
        }
    }

    public void PlayerGameOver()
    {
        anim.Play("GameOverEnter");
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
