using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Vector2 spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GameObject[] enemies;

    public GUIText scoreText;
    public GUIText healthText;
    public GUIText restartText;
    public GUIText gameOverText;

    private Dimension current;
    private int activeEnemies;
    private bool gameOver;
    private bool restart;
    private int score;

    public Dimension getDimension()
    {
        return current;
    }

    public void setDimention(Dimension d)
    {
        current = d;
    }

    // Use this for initialization
    void Start () {
        activeEnemies = 0;
        gameOver = false;
        restart = false;
        spawnWait = 10;
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        UpdateScoreText();
        UpdateHealthText();
        //StartCoroutine(SpawnWaves());
	}
	
    void Update()
    {
        if (restart)
        {
            if(Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    /*
    IEnumerator SpawnWaves()
    {
        
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            int encountSize = (int)Random.Range(4, 9);
            for (int i = 0; i < encountSize; i++)
            {
                GameObject enemy = enemies[Random.Range(0, enemies.Length)];
                Vector2 spawnPoint = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPoint, spawnRotation);
                //activeEnemies++;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press R to Restart";
                restart = true;
                break;
            }
        }

    }
    */

    public void EnemyKilled()
    {
        //activeEnemies--;
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateHealthText()
    {
        int currentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getHealth();
        healthText.text = "Health: " + currentHealth;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    
}
