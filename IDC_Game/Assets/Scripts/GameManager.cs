using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Vector2 spawnRange;
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

    private float nextSpawn;
    private float nextWave;
    private bool waveSpawning;
    private int encountSize;


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
        nextWave = Time.time + startWait;
        nextSpawn = Time.time;
        waveSpawning = false;
        UpdateScoreText();
        UpdateHealthText();
        //StartCoroutine(SpawnWaves());
	}
	
    void Update()
    {
        MoveEnemies();
        if (gameOver)
        {
            restartText.text = restartText.text = "Press R to Restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            //SpawnWaves();
        }
    }

    void SpawnWaves()
    {
        if (Time.time > nextWave && activeEnemies == 0)
        {
            encountSize = (int)Random.Range(4, 9);
            waveSpawning = true;
        }
        if (Time.time > nextSpawn && waveSpawning == true)
        {
            nextSpawn = Time.time + spawnWait;
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Vector2 spawnPoint = new Vector2(Random.Range(-spawnRange.x, spawnRange.x), spawnRange.y);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(enemy, spawnPoint, spawnRotation);
            activeEnemies++;
            if (activeEnemies == encountSize)
            {
                waveSpawning = false;
            }
        }
    }

    public void EnemyKilled()
    {
        activeEnemies--;
        if (activeEnemies == 0)
        {
            nextWave = Time.time + waveWait;
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

    private void MoveEnemies ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach ( GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().UpdateMovement();
        }
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
