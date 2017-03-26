using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack_Basic : MonoBehaviour {

    public enum AttackPattern { normal, laser, sweep }


    public AttackPattern pattern;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public int maxNumOfShots;
    public float rotationSpeed;

    private Dimension original;
    private bool canAttack;
    private float nextFire;
    private GameObject bullet;
    private float maxRotation;
    private int currentShotCount;

	// Use this for initialization
	void Start ()
    {
        canAttack = false;
        currentShotCount = maxNumOfShots;
        original = GetComponent<EnemyDraw>().getDimension();
    }

	// Update is called once per frame
	void Update () {
		if (canAttack == true)
        {
            while (currentShotCount > 0)
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    currentShotCount--;
                    bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    bullet.GetComponent<EnemyBullet>().setDimension(original);
                    if (pattern == AttackPattern.sweep)
                    {
                        gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, maxRotation * Mathf.Sin(Time.time * rotationSpeed));
                    }
                }
            }
            canAttack = false;
            currentShotCount = maxNumOfShots;
            if(pattern == AttackPattern.sweep)
            {
                gameObject.transform.rotation = Quaternion.identity;
            }
            gameObject.GetComponent<EnemyMovement>().Fired();
        }
	}

    public void Attack()
    {
        canAttack = true;
    }
}
