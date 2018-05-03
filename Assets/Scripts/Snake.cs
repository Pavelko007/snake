using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public List<GameObject> StartConfiguration;
    public GameObject SnakeSegment;

    private float lastStepTime;
    private float stepDuration = .5f;
    private LinkedList<GameObject> snakeSegmentsList = new LinkedList<GameObject>();
    private Vector3 newSegmentPosition;
    private bool createNewSegment;

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
	    if (Input.GetKeyDown(KeyCode.G))
	    {
	        createNewSegment = true;
	        newSegmentPosition = snakeSegmentsList.Last.Value.transform.position;
	    }

	    if (Time.time - lastStepTime > stepDuration)
	    {
	        Vector3 headPos = snakeSegmentsList.First.Value.transform.position;
	        Vector3 headPosNext = headPos + Vector3.up;

	        snakeSegmentsList.AddFirst(snakeSegmentsList.Last.Value);
            snakeSegmentsList.RemoveLast();
	        snakeSegmentsList.First.Value.transform.position = headPosNext;

	        if (createNewSegment)
	        {
	            createNewSegment = false;
	            var newSegment = Instantiate(SnakeSegment);
	            newSegment.transform.SetParent(transform);
	            newSegment.transform.position = newSegmentPosition;
	            snakeSegmentsList.AddLast(newSegment);
	        }

	        lastStepTime = Time.time;
	    }
		
	}
}
