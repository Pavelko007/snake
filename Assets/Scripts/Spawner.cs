using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SnakePrefab;
    public GameObject BlockPrefab;

	// Use this for initialization
	void Start ()
	{
	}

    public void SpawnSnake()
    {
        Instantiate(SnakePrefab);
        var block = Instantiate(BlockPrefab);
        block.transform.position = GetRandomPosition();
    }

    private static Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-3,3), Random.Range(-3, 3), 0);
    }

    // Update is called once per frame
	void Update () {
		
	}
}
