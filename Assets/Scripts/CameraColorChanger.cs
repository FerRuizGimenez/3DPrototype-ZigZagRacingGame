using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{
    public Color[] colors;

    private void Start() 
    {
        StartCoroutine("ColorChanger");    
    }
    IEnumerator ColorChanger()
    {
        while(true)
        {
            int randColor = Random.Range(0, 5);

            Camera.main.backgroundColor = colors[randColor];

            yield return new WaitForSeconds(5.0f);
        }
    }
}
