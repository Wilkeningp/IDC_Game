using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_mover : MonoBehaviour {

    public float scrollSpeed;
    public float titleSize;
    
    private Vector2 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, titleSize);
        transform.position = startPosition + Vector2.down * newPosition;

	}
}
