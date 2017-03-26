using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int enemyHealth;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player_bullet")
        {
            enemyHealth--;
            if (enemyHealth == 0)
            {
                DestroyObject(gameObject);
            }
            DestroyObject(other.gameObject);
        }
    }
}
