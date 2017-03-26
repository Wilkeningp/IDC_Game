using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

[System.Serializable]
public enum Dimension
{
    Light, Dark
}

public class PlayerController : MonoBehaviour {

    //variables for player ship
    public float speed;
    public Boundary boundary;
    private Rigidbody2D rb;
    public int health;
    private Dimension current;
    private SpriteRenderer rend;
    public Color lightWorld;
    public Color darkWorld;

    public float swapRate;
    private float nextSwap;

    //Fire weapon variables
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    private GameObject bullet;

    void Start()
    {
        current = Dimension.Light;
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            bullet.GetComponent<PlayerBullet>().original = current;
        }
        if (Input.GetButton("Swap") && Time.time > nextSwap)
        {
            nextSwap = Time.time + swapRate;
            if (current == Dimension.Light)
            {
                current = Dimension.Dark;
            }
            else
            {
                current = Dimension.Light;
            }
        }

        if (current == Dimension.Light)
        {
            rend.color = lightWorld;
        }
        else
        {
            rend.color = darkWorld;
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
