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

    private GameObject gm;

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
        gm = GameObject.Find("GameManager");
        gm.GetComponent<GameManager>().setDimention(current);
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            bullet.GetComponent<PlayerBullet>().setDimension(current);
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
            gm.GetComponent<GameManager>().setDimention(current);
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
            gm.GetComponent<GameManager>().UpdateHealthText();
            if (health == 0)
            {
                DestroyObject(gameObject);
                gm.GetComponent<GameManager>().GameOver();
            }
            DestroyObject(other.gameObject);
        }
    }

    public int getHealth()
    {
        return health;
    }
}
