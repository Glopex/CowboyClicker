using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Score Components
    public UnityEvent<string> addScore;
    private int score;

    //HeathBar Components
    public int maxHealth =100;
    public int health;
    public HealthBar healthBar;

    private void Start()
    {
        UpdateUI();
        health = maxHealth;
        healthBar.SetHealth(health);
    }

    private void Update()
    {
        
    }

    public void AddScore(int scoreAmt)
    {
        score += scoreAmt;
        UpdateUI();
    }

    private void UpdateUI()
    {
        addScore.Invoke(score.ToString());
    }

    public void EditHealth(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }
}