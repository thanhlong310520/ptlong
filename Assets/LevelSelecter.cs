using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour
{
    public Button[] levelbuttons;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelbuttons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelbuttons[i].interactable = false;
            }
        }
    }
    public void Select(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void rePlay()
    {
        
        LevelManager();
    }
    void LevelManager()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        for (int i = 0; i < levelbuttons.Length; i++)
        {
            if (i + 1 > 1)
            {
                levelbuttons[i].interactable = false;
            }
        }
    }
}
