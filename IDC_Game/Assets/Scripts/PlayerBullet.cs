using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed;
    private Dimension original;
    private Rigidbody2D rb;
    private GameObject gm;

    private SpriteRenderer rend;
    public Color hidden;
    public Color revealed;  

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager");
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(0, 1);
        rb.velocity = direction * speed;
    }

    void Update()
    {
        Dimension current = gm.GetComponent<GameManager>().getDimension();
        if (current == original)
        {
            rend.color = revealed;
        }
        else
        {
            rend.color = hidden;
        }
    }

    public void setDimension(Dimension d)
    {
        original = d;
    }
}
