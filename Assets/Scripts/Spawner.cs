using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    public GameObject BlockPrefab;
    private Snake.Factory snakeFactory;
    private GameObject snake;
    private GameObject collectableSegment;

    [Inject]
    void Construct(Snake.Factory snakeFactory)
    {
        this.snakeFactory = snakeFactory;
    }

    public void SpawnSnake()
    {
        snake = snakeFactory.Create().gameObject;
    }

    public void SpawnSegment()
    {
        collectableSegment = Instantiate(BlockPrefab, GridManager.GetRandomPosition(), Quaternion.identity);
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
}
