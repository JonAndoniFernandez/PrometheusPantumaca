using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour
{

    public float clampSpeed = 3;
    public Vector3 desiredScale;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetButton("Fire1"))
            StartCoroutine(GrabBonfire(collision.transform));
    }

    IEnumerator GrabBonfire(Transform playerTransform)
    {
        Vector2 target = new Vector2(playerTransform.position.x, playerTransform.position.y + 1f);
        Vector2 scaleTransform = transform.localScale;

        while (Vector2.Distance(transform.position, target) > 0.2)
        {
            target = new Vector2(playerTransform.position.x, playerTransform.position.y + 1f);
            
            transform.position = Vector2.Lerp(transform.position, target, Time.deltaTime * clampSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * clampSpeed);
            
            yield return null;
        }
        playerTransform.GetComponent<PlayerController>().grabingBonfire = true;

        transform.localScale = desiredScale;
        transform.position = target;
        transform.parent = playerTransform;
    }
}
