using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public List<GameObject> StartConfiguration;
    public GameObject SnakeSegment;

    private GameObject snakeSegment;
    private float lastStepTime;
    private float stepDuration = .5f;
    private LinkedList<GameObject> snakeSegmentsList = new LinkedList<GameObject>();

    void Awake()
    {
        lastStepTime = Time.time;
        foreach (var segment in StartConfiguration)
        {
            snakeSegmentsList.AddLast(segment);
        }
    }
	

	// Update is called once per frame
	void Update () {
	    if (Time.time - lastStepTime > stepDuration)
	    {
	        Vector3 headPos = snakeSegmentsList.First.Value.transform.position;
	        Vector3 headPosNext = headPos + Vector3.up;

	        snakeSegmentsList.AddFirst(snakeSegmentsList.Last.Value);
            snakeSegmentsList.RemoveLast();
	        snakeSegmentsList.First.Value.transform.position = headPosNext;

	        lastStepTime = Time.time;
	    }
		
	}
}
