using Snake.Installers;
using UnityEngine;
using Zenject;

namespace Snake
{
    public class Spawner 
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
            collectableSegment = GameObject.Instantiate(settings.CollectablePrefab, GridManager.GetRandomPosition(), Quaternion.identity);
        }

        public void RespawnAll()
        {
            GameObject.DestroyImmediate(snake);
            snake = null;
            GameObject.DestroyImmediate(collectableSegment);
            collectableSegment = null;

            SpawnSnake();
            SpawnSegment();
        }
    }
}
