using UnityEngine;
using Zenject;

namespace Snake.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameInstaller.Settings GameSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(GameSettings);
        }
    }
}