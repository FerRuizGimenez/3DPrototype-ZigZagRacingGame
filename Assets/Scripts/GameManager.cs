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
    public GameObject menuUI;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreTxt;
    AudioSource audioSource;
    public AudioClip[] gameMusic;
    int score = 0;
    int highScore;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }   

        audioSource = GetComponent<AudioSource>(); 
    }
    private void Start() 
    {
        highScore = PlayerPrefs.GetInt("HighScore");  
        highScoreText.text = "Best Score : " + highScore.ToString();      
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
        menuUI.SetActive(false);
        gameplayUI.SetActive(true);
        audioSource.clip = gameMusic[1];
        audioSource.Play();
        StartCoroutine(UpdateScore());
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine(UpdateScore());
        SaveHighScore(); 
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

    public void IncrementScore()
    {
        score += 2;
        scoreTxt.text = score.ToString();
        audioSource.PlayOneShot(gameMusic[2], 0.2f);
    }
    private void SaveHighScore()
    {
        if(PlayerPrefs.HasKey("HighScore")) 
        {
            // We already have a highscore
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }   
        else
        {
            // Playing for the first time
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
