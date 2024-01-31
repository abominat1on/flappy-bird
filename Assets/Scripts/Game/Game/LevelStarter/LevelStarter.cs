using Core.Game.UI;
using Core.State;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private Button startGameButton = null;
        [SerializeField] private GameObject gamePlayPanel;
        [SerializeField] private GameObject startPanel;


        private void Awake()
        {
            startGameButton.onClick.AddListener(OnPlayClick);
            SwitchPanels(true);
        }

        private void OnPlayClick()
        {
            LevelController.StartLevel?.Invoke();
            SwitchPanels(false);
            LevelController.Instance.SpawnLocation();
            Time.timeScale = 1;
        }

        private void SwitchPanels(bool isMenu = false)
        {
            gamePlayPanel.SetActive(!isMenu);
            startPanel.SetActive(isMenu);
        }
    }
}