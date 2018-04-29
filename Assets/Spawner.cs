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
    }

    // Update is called once per frame
	void Update () {
		
	}
}
