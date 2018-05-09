using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public Spawner.Settings SpawnerSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(SpawnerSettings);
    }
}