using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] enemies;  // Array of enemy prefabs
    public float spawnTime;
    public float increasedSpawnRate = 1.5f; // New spawn time after reaching score 10
    private bool hasIncreasedSpawnRate = false; // Check if spawn rate has been increased
    private bool hasIncreasedSpawnRatelevel2 = false;
    private bool hasIncreasedSpawnRatelevel3 = false;
    private bool hasIncreasedSpawnRatelevel4 = false;

    private Player player; // Tham chiếu tới Player trong game

    float m_spawnTime;
    int m_score;
    bool isGameOver;
    bool isStartGame = false;

    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.setScoreText("Score:" + m_score);
        player = FindObjectOfType<Player>();

        m_ui.GameSartPanel(true); // Show start panel on game launch
        isStartGame = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowOverPanel(true);
            return;
        }

        // Chỉ spawn kẻ địch nếu trò chơi đã bắt đầu
        if (isStartGame)
        {
            m_spawnTime -= Time.deltaTime;
            if (m_spawnTime <= 0)
            {
                SpawnEnemy();
                m_spawnTime = spawnTime;
            }
        }
    }

    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-9, 10);
        Vector2 spawnPos = new Vector2(randXpos, 6.5f);

        // Randomly select an enemy prefab from the array
        int randomEnemyIndex = Random.Range(0, enemies.Length);

        if (enemies[randomEnemyIndex] != null)
        {
            Instantiate(enemies[randomEnemyIndex], spawnPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void StartGame()
    {
        m_ui.GameSartPanel(false); // Hide the start panel
        isGameOver = false; // Ensure game is not over when starting
        m_spawnTime = spawnTime; // Start the enemy spawning
        m_score = 0; // Reset the score if needed
        m_ui.setScoreText("Score: " + m_score); // Update score text
        isStartGame = true;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        // If running in the Unity editor, stop the play mode.
        UnityEditor.EditorApplication.isPlaying = false;
        #else
                // If running the standalone build, quit the application.
                Application.Quit();
        #endif
    }

    public void OpenIntroGame()
    {
        m_ui.IntroGamePanel(true);
        m_ui.GameSartPanel(false);
    }

    public void CloseIntroGame()
    {
        m_ui.GameSartPanel(true);
        m_ui.IntroGamePanel(false);
    }

    public void SetScore(int score)
    {
        m_score = score;
    }

    public int GetScore()
    {
        return m_score;
    }

    public void ScoreIncreament()
    {
        if (isGameOver)
        {
            return;
        }
        m_score++;
        m_ui.setScoreText("Score:" + m_score);

        // Check if score reaches 10 and increase spawn rate
        if (m_score >= 8 && !hasIncreasedSpawnRate)
        {
            IncreaseSpawnRate();
            IncreasePlayerDamage(2, 3);  // Gọi hàm để tăng damage
        }

        if (m_score >= 16 && !hasIncreasedSpawnRatelevel2)
        {
            spawnTime = 1.0f; // Giảm thời gian spawn hơn nữa
            hasIncreasedSpawnRatelevel2 = true;

        }
        if (m_score >= 30 && !hasIncreasedSpawnRatelevel3)
        {
            spawnTime = 0.5f;
            hasIncreasedSpawnRatelevel3 = true;
            IncreasePlayerDamage(3, 4);
        }
        if (m_score >= 40 && !hasIncreasedSpawnRatelevel4)
        {
            spawnTime = 0.35f;
            hasIncreasedSpawnRatelevel4 = true;
        }
    }

    private void IncreasePlayerDamage(int minDam, int maxDame)
    {
        if (player != null)
        {
            player.SetDamage(Random.Range(minDam, maxDame));
            Debug.Log("increa dame" + player.GetDamage());
        }
    }

    public void SetGameOver(bool state)
    {
        isGameOver = state;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void SetStartGame(bool state)
    {
        isStartGame = state;
    }

    public bool IsStartGame()
    {
        return isStartGame;
    }

    // Method to increase the spawn rate of enemies
    private void IncreaseSpawnRate()
    {
        spawnTime = increasedSpawnRate;
        hasIncreasedSpawnRate = true;
    }

}
