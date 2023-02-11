using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 distance;
    public float smoothValue;

    private void Start() 
    {
        distance = target.position - transform.position;    
    }

    private void Update() 
    {
        if(target.position.y >= 0)
        {
            Follow();  
        }
          
    }

    private void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValue * Time.deltaTime);

    }
}
