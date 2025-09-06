using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;
    public Slider healthSlider; // Slider to represent health
    public GameObject gameSartPanel;
    public GameObject introGamePanel;


    public void setScoreText(string text)
    {
        if (scoreText != null)
        {
            scoreText.text = text;  
        }
    }

    public void ShowOverPanel(bool isShow)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(isShow);
        }
    }

    public void GameSartPanel(bool isShow)
    {
        if (gameSartPanel != null)
        {
            gameSartPanel.SetActive(isShow);
        }
    }

    public void IntroGamePanel(bool isShow)
    {
        if (introGamePanel != null)
        {
            introGamePanel.SetActive(isShow);
        }
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth; // Update slider value to current health
        }
    }
}
