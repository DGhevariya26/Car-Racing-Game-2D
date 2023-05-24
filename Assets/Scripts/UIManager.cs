using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text scoreText;
    bool gameOver;
    int score;

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        gameOver = false;
        score = 0;
        InvokeRepeating(nameof(scoreUpdate), 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score;
    }

    void scoreUpdate()
    {
        if(!gameOver)
        {
            score += 1;
        }
        
    }

    public void GameOverActivated()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }

        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

    }

}
