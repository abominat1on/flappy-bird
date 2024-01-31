using Core.State;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.UI
{
    public class PauseButton : MonoBehaviour
    {
        private Button mainButton = null;

        private void Start()
        {
            mainButton = GetComponent<Button>();
            mainButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Time.timeScale = 0;
            GameObject.FindObjectOfType<PauseWindow>(true).Show();
        }
    }
}