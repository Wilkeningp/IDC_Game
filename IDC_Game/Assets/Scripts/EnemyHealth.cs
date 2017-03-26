using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private GameObject gm;
    private Dimension orginal;
    public int enemyHealth;
    public int scoreValue;

    void Start()
    {
        gm = GameObject.Find("GameManager");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player_bullet")
        {
            Dimension current = gm.GetComponent<GameManager>().getDimension();
            if (current == orginal)
            {
                enemyHealth--;
                if (enemyHealth <= 0)
                {
                    gm.GetComponent<GameManager>().EnemyKilled();
                    gm.GetComponent<GameManager>().AddScore(scoreValue);
                    DestroyObject(gameObject);
                }
                DestroyObject(other.gameObject);
            }
        }
    }
}
