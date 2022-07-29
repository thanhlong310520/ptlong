using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public WayPoints wayPoints;
    public float speed = 10;
    Transform target;
    int wavePointxndex = 0;

    // heath;
    public int starthealth = 100;
    int health;
    public GameObject EnemyDieEffect;
    public int bonus = 50;

    public Image healthUI;
    // Start is called before the first frame update
    private void Awake()
    {
        wayPoints = GameObject.FindObjectOfType<WayPoints>();
    }
    void Start()
    {
        health = starthealth;
        healthUI.fillAmount = 1;
        target = wayPoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
        if(Vector3.Distance(transform.position,target.position) <= 0.2f)
        {
            GetNextTarget();
        }
    }
    void GetNextTarget()
    {
        if(wavePointxndex >= wayPoints.points.Length - 1)
        {
            EndPart();
            return;
        }
        wavePointxndex++;
        target = wayPoints.points[wavePointxndex];
    }
    void EndPart()
    {
        WaveSqawner.EnemiesAlive--;
        PlayerStart.Lives--;
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthUI.fillAmount = (float)health / starthealth;
        if(health <= 0)
        {
            GameManager.score++;
            Die();
        }
    }
    void Die()
    {
        PlayerStart.money += bonus;
        GameObject effect = Instantiate(EnemyDieEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSqawner.EnemiesAlive--;     
        Destroy(gameObject);
    }
}
