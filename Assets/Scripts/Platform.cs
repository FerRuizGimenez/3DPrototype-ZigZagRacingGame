using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.1f);
        }    
    }
}
