using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanNeeded : MonoBehaviour
{
    public bool activated = false;



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !activated)
        {
            if(collision.GetComponent<PlayerController>().grabingBonfire)
            {
                GetComponent<Renderer>().material.color = Color.yellow;

                if (Input.GetButton("Fire1"))
                    LetBonfireOnHuman(collision.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !activated)
        {
            GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    void LetBonfireOnHuman(Transform playerTransform)
    {
        PlayerController playerController = playerTransform.GetComponent<PlayerController>();

        //No tiene la antorcha en su poder
        if (playerController.grabingBonfire == false)
            return;
        //Tiene en poder la antorcha
        else
        {
            activated = true;
            GetComponent<Renderer>().material.color = Color.blue;
        }

    }
}
