using System;
using UnityEngine;
using Zenject;

namespace Snake.Installers
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Inject] private Settings settings;

        public override void InstallBindings()
        {
            Container.BindFactory<Snake, Snake.Factory>().FromComponentInNewPrefab(settings.SnakePrefab);
        }

        [Serializable]
        public class Settings
        {
            public GameObject SnakePrefab;
            public GameObject CollectablePrefab;
        }
    }
}