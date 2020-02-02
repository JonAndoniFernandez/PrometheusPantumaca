using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class BonfireScript : MonoBehaviour
{

    public float clampSpeed = 1.5f;
    public Transform playerDetected;
    public Vector3 targetScale;
    public bool grabbed = false;
    private GameObject pressToInteractUI;
    [SerializeField] GameObject lightPlayer;

    private void Start()
    {
        pressToInteractUI = transform.GetChild(1).gameObject;
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.tag == "Player" && !grabbed)
        {
            pressToInteractUI.active = true;

            if(Input.GetButton("Fire1"))
                StartCoroutine( GrabbingBonfire(collision.transform.GetChild(0)));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && !grabbed)
        {
            pressToInteractUI.active = false;
        }
    }

    IEnumerator GrabbingBonfire(Transform playerTarget)
    {
        //Vector2 target = new Vector2(playerTarget.position.x, playerTarget.position.y + 1);
        targetScale = new Vector3 (4.5F, 4.5F, 4.5F);
        float timerToGo = 0;

        while (Vector3.Distance(transform.position, playerTarget.position) > 0.2)
        {
            timerToGo += Time.deltaTime;
            //target = new Vector2(playerTarget.position.x, playerTarget.position.y + 1);

            transform.position = Vector3.Lerp(transform.position, playerTarget.position, Time.deltaTime * clampSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.488f, 0.488f, 0), Time.deltaTime * clampSpeed);
            transform.GetChild(0).localScale = Vector3.Lerp(transform.localScale, new Vector3 (35, 35 ,35 ), Time.deltaTime * clampSpeed);

            if (timerToGo > 0.2f)
                break;

            yield return null;

        }

        transform.position = playerTarget.position;
        transform.GetChild(0).localScale = new Vector3(35, 35, 35);
        transform.localScale = new Vector3(0.488f, 0.488f, 0);
        playerTarget.GetComponentInParent<PlayerController>().grabbingBonfire = true;
        playerDetected = playerTarget;
        pressToInteractUI.active = false;
        grabbed = true;
        lightPlayer.active = false;
    }


    private void Update()
    {
        if(playerDetected != null)
            transform.position = Vector3.Lerp(transform.position, playerDetected.position, Time.deltaTime * clampSpeed * 2);
    }
}
