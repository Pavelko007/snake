using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject SnakeSegment;

	// Use this for initialization
	void Start ()
	{
	    GameObject snakeSegment = Instantiate(SnakeSegment);
        snakeSegment.transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
