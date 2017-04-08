using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_painter : MonoBehaviour {

    public Color lightWorld;
    public Color darkWorld;

    private Dimension current;
    private GameObject gm;
    private SpriteRenderer rend;

    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GameManager");
        current = gm.GetComponent<GameManager>().getDimension();
        rend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        current = gm.GetComponent<GameManager>().getDimension();

        if (current == Dimension.Light)
        {
            rend.color = lightWorld;
        }
        else
        {
            rend.color = darkWorld;
        }
    }
}
