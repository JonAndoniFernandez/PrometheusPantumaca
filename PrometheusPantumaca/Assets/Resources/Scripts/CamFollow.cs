using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] float clampSpeed;

    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;

    [SerializeField] float downLimit;
    [SerializeField] float upLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetToGo = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetToGo, Time.deltaTime + clampSpeed);

        
        if (transform.position.x < leftLimit)
            transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
        else if (transform.position.x > rightLimit)
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);

        if (transform.position.z > upLimit)
            transform.position = new Vector3(transform.position.x, transform.position.y, upLimit);
        else if (transform.position.z < downLimit)
            transform.position = new Vector3(transform.position.x, transform.position.y, downLimit);
            
    }
}
