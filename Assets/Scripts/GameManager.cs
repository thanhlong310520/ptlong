using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int round;
    public static int score;
    public static int roundOnLevel;
    public static bool gameEnable = false;
    public GameObject gameOverUI;

    public int levelnext = 2;
    public string nameNextLevel = "Level2";
    public GameObject WinnerPanel;
    // Start is called before the first frame update
    void Awake()
    {
        round = 0;
        gameOverUI.SetActive(false);
    }
    private void Start()
    {
        WinnerPanel.SetActive(false);
        gameEnable = false;
        round = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnable)
        {
            return;
        }
        if(PlayerStart.Lives == 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameOverUI.SetActive(true);
        gameEnable = true;
        Debug.Log("endgame");
    }
    public void LevelWon()
    {
        PlayerPrefs.SetInt("levelReached", levelnext);
        WinnerPanel.SetActive(true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nameNextLevel);
    }
    public void LoadSelectLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }

}
