using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanNeeded : MonoBehaviour
{

    public bool activatedBonfire = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && activatedBonfire == false)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player.grabbingBonfire == true && Input.GetButton("Fire1"))
            {
                activarAntorchaHumana();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" && activatedBonfire == false)
        {
            GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    void activarAntorchaHumana()
    {
        activatedBonfire = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
