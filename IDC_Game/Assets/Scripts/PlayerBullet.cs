using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(0, 1);
        rb.velocity = direction * speed;
    }
}
