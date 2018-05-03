using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Snake : MonoBehaviour
{
    public List<GameObject> StartConfiguration;
    public GameObject SnakeSegment;

    private float lastStepTime;
    private float stepDuration = .5f;
    private LinkedList<GameObject> snakeSegmentsList = new LinkedList<GameObject>();
    private Vector3 newSegmentPosition;
    private bool createNewSegment;
    private Vector3 moveVector;
    private float stepDist = 1.0f;
    private GameObject newSegment;
    private Spawner spawner;

    [Inject]
    void Construct(Spawner spawner)
    {
        this.spawner = spawner;
    }

    void Awake()
    {
        lastStepTime = Time.time;
        foreach (var segment in StartConfiguration)
        {
            snakeSegmentsList.AddLast(segment);
        }

        moveVector = Vector3.up;
    }
    
	// Update is called once per frame
	void Update ()
    {
	    HandleInput();

	    if (Time.time - lastStepTime > stepDuration)
	    {
	        Vector3 headPos = snakeSegmentsList.First.Value.transform.position;
	        

	        Vector3 headPosNext = headPos + stepDist * moveVector;

	        snakeSegmentsList.AddFirst(snakeSegmentsList.Last.Value);
            snakeSegmentsList.RemoveLast();
	        snakeSegmentsList.First.Value.transform.position = headPosNext;

	        if (createNewSegment)
	        {
	            createNewSegment = false;
	            newSegment.transform.SetParent(transform, true);
	            snakeSegmentsList.AddLast(newSegment);

	            spawner.SpawnNextSegment();
	        }

	        lastStepTime = Time.time;
	    }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            createNewSegment = true;
            newSegment = other.gameObject;
            newSegment.tag = "Untagged";
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveVector = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveVector = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveVector = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveVector = Vector3.down;
        }
    }

    public class Factory : Factory<Snake> { }
}
