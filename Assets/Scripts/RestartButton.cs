using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Snake
{
    public class RestartButton : MonoBehaviour
    {
        private GameManager gameManager;

        [Inject]
        void Construct(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        void Awake ()
        {
            GetComponent<Button>().onClick.AddListener(OnRestartButtonClicked);
        }

        public void OnRestartButtonClicked()
        {
            gameManager.Restart();
        }
    }
}
