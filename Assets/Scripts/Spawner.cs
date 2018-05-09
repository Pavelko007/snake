using System;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    private Snake.Factory snakeFactory;
    private GameObject snake;
    private GameObject collectableSegment;
    private Settings settings;

    [Inject]
    void Construct(Snake.Factory snakeFactory, Settings settings)
    {
        this.settings = settings;
        this.snakeFactory = snakeFactory;
    }

    public void SpawnSnake()
    {
        snake = snakeFactory.Create().gameObject;
    }

    public void SpawnSegment()
    {
        collectableSegment = Instantiate(settings.CollectablePrefab, GridManager.GetRandomPosition(), Quaternion.identity);
    }

    public void RespawnAll()
    {
        DestroyImmediate(snake);
        snake = null;
        DestroyImmediate(collectableSegment);
        collectableSegment = null;

        SpawnSnake();
        SpawnSegment();
    }

    [Serializable]
    public class Settings
    {
        public GameObject CollectablePrefab;
    }
}
