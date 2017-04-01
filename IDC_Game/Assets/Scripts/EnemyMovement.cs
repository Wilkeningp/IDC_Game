using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;

    private GameObject[] movePoints;
    public GameObject currentMP;
    public float proxyRange;
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
	
	
	public void UpdateMovement () {
        if (hasFired == true)
        {
            if (moving == false)
            {
                currentMP = movePoints[(int)Random.Range(0, movePoints.Length)];
                moving = true;
            }
            Vector2 heading = currentMP.transform.position - gameObject.transform.position;
            //float distance = Vector2.Distance(gameObject.transform.position, currentMP.transform.position);
            if (heading.sqrMagnitude < (proxyRange * proxyRange))
            {
                //rb.position = currentMP.transform.position;
                rb.velocity = new Vector2(0.0f, 0.0f);
                moving = false;
                //hasFired = false;
                //gameObject.GetComponent<EnemyAttack_Basic>().Attack();
            }
            else
            {
                rb.velocity = heading.normalized * speed;
            }
        }
	}

    public void Fired()
    {
        hasFired = true;
    }
}
