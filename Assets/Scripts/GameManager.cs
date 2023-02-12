using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted;
    public GameObject platformSpawner;
    public GameObject gameplayUI;
    public TextMeshProUGUI scoreTxt;
    int score = 0;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }    
    }

    private void Update() 
    {
        if(!gameStarted)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }    
    }
    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
        gameplayUI.SetActive(true);
        StartCoroutine(UpdateScore());
    }

    public void GameOver()
    {
        //gameStarted = false;
        platformSpawner.SetActive(false);
        Invoke("ReloadLevel", 0.5f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            score++;
            scoreTxt.text = score.ToString();
        }
    }
}
