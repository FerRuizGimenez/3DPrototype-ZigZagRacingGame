using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;
    bool stop;

    private void Start() 
    {
        lastPosition = lastPlatform.position;   
        StartCoroutine(SpawnPlatforms()); 
    }

    private void Update() 
    {
        // if(Input.GetKey(KeyCode.Space))
        // {
        //     SpawnPlatforms();
        // }
    }

    IEnumerator SpawnPlatforms()
    {
        while(!stop)
        {
            GeneratePosition();

            GameObject platformInstance = Instantiate(platformPrefab, newPos, Quaternion.identity);
            platformInstance.transform.SetParent(gameObject.transform);

            lastPosition = newPos;

            yield return new WaitForSeconds(0.1f); 
        }         
    }

    // void SpawnPlatforms()
    // {
    //     GeneratePosition();

    //     Instantiate(platformPrefab, newPos, Quaternion.identity);

    //     lastPosition = newPos;
    // }
    private void GeneratePosition()
    {
        newPos = lastPosition;

        int rand = Random.Range(0, 2);

        if(rand > 0)
        {
            newPos.x += 2.0f;
        } 
        else
        {
            newPos.z += 2.0f;
        }
        
    }
    
}
