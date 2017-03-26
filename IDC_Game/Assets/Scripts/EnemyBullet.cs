using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed;
    private Dimension original;
    private Rigidbody2D rb;
    private GameObject gm;
    private SpriteRenderer rend;

    public Color hidden;
    public Color revealed;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager");
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
