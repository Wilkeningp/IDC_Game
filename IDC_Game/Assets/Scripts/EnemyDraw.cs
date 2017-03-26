﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDraw : MonoBehaviour {

    private GameObject gm;
    public Dimension orginal;
    public Color hidden;
    public Color revealed;
    private SpriteRenderer rend;

    void Start()
    {
        gm = GameObject.Find("GameManager");
        rend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Dimension current = gm.GetComponent<GameManager>().getDimension();
        
        if (current == orginal)
        {
            rend.color = revealed;
        }
        else
        {
            rend.color = hidden;
        }
	}
}
