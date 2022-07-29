using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSqawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform sqawnPoint;

    public float timeSqawn = 2f;
    float currentTime = 5;
    int waveNumber;
    public GameManager gameManager;
    public Text waveCountdownText;
    private void Start()
    {
        timeSqawn = 2f;
        EnemiesAlive = 0;
        currentTime = 5;
        waveNumber = 0;
        this.enabled = true;
        GameManager.roundOnLevel = waves.Length;
        waveCountdownText.text = Mathf.Round(currentTime).ToString();
    }
    void Update()
    {
        
        if(waveNumber == waves.Length && EnemiesAlive == 0)
        {
            gameManager.LevelWon();
            Debug.Log("level won");
            this.enabled = false;
        }
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        if (currentTime <= 0)
        {
            GameManager.round++;
            StartCoroutine(SqawnWave());
            currentTime = timeSqawn;
        }        
        currentTime = currentTime -Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0f, Mathf.Infinity);
        waveCountdownText.text = Math.Round(currentTime,2).ToString();

        
        
    }

    IEnumerator SqawnWave()
    {
        Wave wave = waves[waveNumber];
        for (int i = 0; i <wave.count; i++)
        {
            SqawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }
        waveNumber++;
        

    }
    void SqawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, sqawnPoint.position, Quaternion.identity);
        EnemiesAlive++;
    }
}
