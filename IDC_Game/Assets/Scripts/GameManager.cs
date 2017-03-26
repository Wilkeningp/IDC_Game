using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Vector2 spawnpoint;
    public float spawnWait;
    public float startWait;
    private List<GameObject>[] encounters;

    public GameObject enemy1Light;
    public GameObject enemy2Light;
    public GameObject enemy3Light;

    public GameObject enemy1Dark;
    public GameObject enemy2Dark;
    public GameObject enemy3Dark;

    private Dimension current;

    public Dimension getDimension()
    {
        return current;
    }

    public void setDimention(Dimension d)
    {
        current = d;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
    }

    
}
