using Core.State;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Game.UI
{
    public class PauseWindow : Window
    {
        [SerializeField] private Button exitButton = null;
        [SerializeField] private Button restartButton = null;

        protected override void OnShow()
        {
            exitButton.onClick.AddListener(OnExitClick);
            restartButton.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            GameObject.FindObjectOfType<PauseWindow>(true).gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnExitClick()
        {
            Time.timeScale = 1;
            GameObject.FindObjectOfType<PauseWindow>(true).gameObject.SetActive(false);
        }

        protected override void OnClose() { }
    }
}