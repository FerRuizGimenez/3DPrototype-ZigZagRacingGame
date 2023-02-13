using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject diamondPrefab;

    private void Start() 
    {
        int randDiamond = Random.Range(0, 5);
        Vector3 diamondPos = transform.position;
        diamondPos.y += 1;

        if(GameManager.instance.gameStarted)
        {
            if(randDiamond < 1)
            {
                // Spawn the diamond
                GameObject diamondInstance = Instantiate(diamondPrefab, diamondPos, diamondPrefab.transform.rotation);
                diamondInstance.transform.SetParent(gameObject.transform);
            }         
            // 1 2 3 4 Don't spawn the diamond
        }
    
    }
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
