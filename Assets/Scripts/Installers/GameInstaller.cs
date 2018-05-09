using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    public GameObject SnakePrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<Snake, Snake.Factory>().FromComponentInNewPrefab(SnakePrefab);
    }
}