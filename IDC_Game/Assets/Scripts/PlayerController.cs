using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    //variables for player ship
    public float speed;
    public Boundary boundary;
    private Rigidbody2D rb;
    public int health;

    //Fire weapon variables
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * speed;

        rb.position = new Vector2
            (
                Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax)
            );

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy_bullet")
        {
            health--;
            if (health == 0)
            {
                DestroyObject(gameObject);
                //TODO: Game Over
            }
            DestroyObject(other.gameObject);
        }
    }
}
