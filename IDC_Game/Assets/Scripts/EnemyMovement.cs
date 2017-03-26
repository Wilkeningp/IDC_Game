using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;

    private GameObject[] movePoints;
    private GameObject currentMP;
    private bool moving;
    private bool hasFired;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        movePoints = GameObject.FindGameObjectsWithTag("Move Point");
        rb = GetComponent<Rigidbody2D>();
        moving = false;
        hasFired = true;
    }
	
	
	void FixedUpdate () {
        while (hasFired == true)
        {
            if (moving == false)
            {
                currentMP = movePoints[(int)Random.Range(0, movePoints.Length)];
                moving = true;
            }
            float distance = Vector2.Distance(gameObject.transform.position, currentMP.transform.position);
            if (distance <= speed)
            {
                rb.position = currentMP.transform.position;
                moving = false;
                hasFired = false;
            }
            else
            {
                Vector2 direction = gameObject.transform.position - currentMP.transform.position;
                rb.velocity = direction * speed;
            }
        }
	}

    public void Fired()
    {
        hasFired = true;
    }
}
