using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public enum BulletType { normal, boomerang, blob };

    public float speed;
    public BulletType type;
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

        if (type == BulletType.normal)
        {
            Vector2 direction = new Vector2(0, -1);
            rb.velocity = direction * speed;
        }
        if (type == BulletType.boomerang)
        {
            //TODO
        }
        if (type == BulletType.blob)
        {
            //TODO
        }
    }
	
	// Update is called once per frame
	void Update () {
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

    public void setDimension (Dimension d)
    {
        original = d;
    }

    public Dimension getDimension()
    {
        return original;
    }
}
