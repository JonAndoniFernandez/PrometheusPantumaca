using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanNeeded : MonoBehaviour
{

    public bool activatedBonfire = false;

    public UnityEngine.Experimental.Rendering.Universal.Light2D Light2D;
    public Transform pressToInteractUI;
    PlayerController player = null;


    private void Start()
    {
        Light2D.lightType = UnityEngine.Experimental.Rendering.Universal.Light2D.LightType.Parametric;
        pressToInteractUI = transform.GetChild(1);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player" && activatedBonfire == false)
        {
            player = collision.GetComponent<PlayerController>();
            if (player.grabbingBonfire == true)
            {
                pressToInteractUI.gameObject.active = true;
                if (Input.GetButton("Fire1"))
                    activarAntorchaHumana();
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.tag == "Player")
        {
            pressToInteractUI.gameObject.active = false;
        }
    }

    void activarAntorchaHumana()
    {
        activatedBonfire = true;
        GetComponent<Renderer>().material.color = Color.blue;
        pressToInteractUI.gameObject.active = false;
        Light2D.color = new Color(0.5f, 1f, 1f, 1f);
    }
}
