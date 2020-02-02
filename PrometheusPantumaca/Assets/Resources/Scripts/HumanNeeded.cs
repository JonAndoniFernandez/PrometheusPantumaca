using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanNeeded : MonoBehaviour
{

    public bool activatedBonfire = false;

    public UnityEngine.Experimental.Rendering.Universal.Light2D Light2D;
    public Transform pressToInteractUI;
    PlayerController player = null;
    Animator anim;

    SphereCollider Collider;


    private void Start()
    {
        Light2D.lightType = UnityEngine.Experimental.Rendering.Universal.Light2D.LightType.Parametric;
        pressToInteractUI = transform.GetChild(1);
        Collider = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();

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

        if (collision.tag == "Player" && activatedBonfire)
        {
            player = collision.GetComponent<PlayerController>();
            transform.Find("BrotherSoundEffect").gameObject.active = true;
            player.SetZoneSecure(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.tag == "Player")
        {
            pressToInteractUI.gameObject.active = false;
            player = collision.GetComponent<PlayerController>();

            player.SetZoneSecure(false);
        }
    }

    void activarAntorchaHumana()
    {
        Collider.radius = 1f;
        activatedBonfire = true;
        GetComponent<Renderer>().material.color = Color.blue;
        pressToInteractUI.gameObject.active = false;
        StartCoroutine("HumanLightAnim");
        Light2D.color = new Color(0.5f, 1f, 1f, 1f);
        anim.SetBool("flameGrabbed", true);

    }

    IEnumerator HumanLightAnim()
    {
        float clampSpeed = 1.5f;

        while(Light2D.transform.localScale.x < .4f)
        {
            Light2D.transform.localScale = Vector3.Lerp(Light2D.transform.localScale, new Vector3(1, 1, 0), Time.deltaTime * clampSpeed);
            yield return null;
        }
    }
}
