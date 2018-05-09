using Snake.Installers;
using UnityEngine;
using Zenject;

namespace Snake
{
    public class Spawner : MonoBehaviour
    {
        private Snake.Factory snakeFactory;
        private GameObject snake;
        private GameObject collectableSegment;
        private GameInstaller.Settings settings;

        [Inject]
        void Construct(Snake.Factory snakeFactory, GameInstaller.Settings settings)
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
    }
}
