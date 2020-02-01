using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour
{

    public float clampSpeed = 1.5f;
    public Transform playerDetected;
    public Vector3 targetScale;
    public bool grabbed = false;

    private void OnTriggerStay(Collider collision)
    {
        if(collision.tag == "Player" && Input.GetButton("Fire1") && !grabbed)
        {
            StartCoroutine( GrabbingBonfire(collision.transform.GetChild(0)));
        }
    }

    IEnumerator GrabbingBonfire(Transform playerTarget)
    {
        //Vector2 target = new Vector2(playerTarget.position.x, playerTarget.position.y + 1);
        targetScale = new Vector3(0.75f, 0.75f, 1);

        while (Vector3.Distance(transform.position, playerTarget.position) > 0.2)
        {
            //target = new Vector2(playerTarget.position.x, playerTarget.position.y + 1);

            transform.position = Vector3.Lerp(transform.position, playerTarget.position, Time.deltaTime * clampSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * clampSpeed);
            yield return null;
        }

        transform.position = playerTarget.position;
        transform.localScale = targetScale;
        playerTarget.GetComponentInParent<PlayerController>().grabbingBonfire = true;
        playerDetected = playerTarget;
        grabbed = true;
    }


    private void Update()
    {
        if(playerDetected != null)
            transform.position = Vector3.Lerp(transform.position, playerDetected.position, Time.deltaTime * clampSpeed * 2);
    }
}
