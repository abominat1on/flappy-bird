using System.Collections;
using System.Collections.Generic;
using Core.State;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.Game.UI
{
    public class LoseWindow : Window
    {
        [SerializeField] private Button exitButton = null;
        [SerializeField] private TextMeshProUGUI curPointsText = null;

        protected override void OnShow()
        {
            Time.timeScale = 0;
            exitButton.onClick.AddListener(OnExitClick);
            curPointsText.text = LevelController.Instance.Points.ToString();
        }

        private void OnExitClick()
        {
            GameObject.FindObjectOfType<LoseWindow>(true).gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); ;
        }

        protected override void OnClose() { }
    }
}