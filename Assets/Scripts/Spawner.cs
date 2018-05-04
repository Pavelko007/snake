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

    private static Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-3,3), Random.Range(-3, 3), 0);
    }

    public void SpawnSegment()
    {
        collectableSegment = Instantiate(BlockPrefab, GetRandomPosition(), Quaternion.identity);
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
