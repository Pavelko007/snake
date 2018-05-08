using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class Snake : MonoBehaviour
{
    public Color SnakeColor = Color.black;
    public Color HeadColor = Color.green;
    public List<GameObject> StartConfiguration;
    public GameObject SnakeSegment;

    private float lastStepTime;
    private float stepDuration = .5f;
    private LinkedList<GameObject> snakeSegmentsList = new LinkedList<GameObject>();
    private Vector3 moveVector;
    private float stepDist = 1.0f;
    private Spawner spawner;
    private string collectableTag = "Collectable";

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

	        GameObject collectable;

	        if (TryGetCollectable(headPosNext, out collectable))
	        {
	            collectable.tag = "Untagged";
                collectable.transform.SetParent(transform, true);
	            snakeSegmentsList.AddFirst(collectable);

	            spawner.SpawnSegment();
	        }
	        else
	        {
	            snakeSegmentsList.AddFirst(snakeSegmentsList.Last.Value);
	            snakeSegmentsList.RemoveLast();
	            snakeSegmentsList.First.Value.transform.position = headPosNext;
            }

	        UpdateColors();

            lastStepTime = Time.time;
	    }
	}

    private void UpdateColors()
    {
        foreach (var segment in snakeSegmentsList)
        {
            segment.GetComponent<Block>().ChangeColor(SnakeColor);
        }
        snakeSegmentsList.First.Value.GetComponent<Block>().ChangeColor(HeadColor);
    }

    private bool TryGetCollectable(Vector3 pos, out GameObject collectable)
    {
        collectable = null;
        var col = Physics2D.OverlapPoint(pos);

        if (col != null && col.gameObject.CompareTag(collectableTag))
        {
            collectable = col.gameObject;
        }

        return collectable != null;
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
