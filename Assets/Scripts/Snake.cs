using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject SnakeSegment;
    private GameObject snakeSegment;
    private float lastStepTime;
    private float stepDuration = .5f;

    void Awake()
    {
        lastStepTime = Time.time;
    }
    // Use this for initialization
	void Start ()
	{
	    snakeSegment = Instantiate(SnakeSegment);
	    snakeSegment.transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time - lastStepTime > stepDuration)
	    {
	        snakeSegment.transform.Translate(Vector3.up);
	        lastStepTime = Time.time;
	    }
		
	}
}
