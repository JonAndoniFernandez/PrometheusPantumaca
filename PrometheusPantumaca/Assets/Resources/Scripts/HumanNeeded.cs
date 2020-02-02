using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanNeeded : MonoBehaviour
{

    public bool activatedBonfire = false;

    public UnityEngine.Experimental.Rendering.Universal.Light2D Light2D;


    private void Start()
    {
        Light2D.lightType = UnityEngine.Experimental.Rendering.Universal.Light2D.LightType.Parametric;
    }

    private void OnTriggerStay(Collider collision)
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
        Light2D.color = new Color(0.5f, 1f, 1f, 1f);
    }
}
