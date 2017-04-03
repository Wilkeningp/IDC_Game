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
        orginal = GetComponent<EnemyDraw>().getDimension();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy tigger Activated");
        if (other.gameObject.tag == "player_bullet" )
        {
            Dimension bullet = other.gameObject.GetComponent<PlayerBullet>().getDimension();
            if (bullet == orginal)
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
