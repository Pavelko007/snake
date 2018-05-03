using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    public GameObject SnakePrefab;
    public GameObject BlockPrefab;
    private Snake.Factory snakeFactory;

    [Inject]
    void Construct(Snake.Factory snakeFactory)
    {
        this.snakeFactory = snakeFactory;
    }
	// Use this for initialization
	void Start ()
	{
	}

    public void SpawnSnake()
    {
        snakeFactory.Create();
        SpawnNextSegment();
    }

    private static Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-3,3), Random.Range(-3, 3), 0);
    }

    public void SpawnNextSegment()
    {
        var block = Instantiate(BlockPrefab);
        block.transform.position = GetRandomPosition();
    }
}
