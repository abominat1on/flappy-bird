using System;
using System.Collections;
using Core.Game;
using Core.Game.UI;
using UnityEngine;

namespace Core.State
{
    public class LevelController : MonoBehaviour
    {
        public int Points { private set; get; }
        private int lineCount = 1;
        [SerializeField] private GameObject obstaclePref = null;
        public static LevelController Instance;
        public static Action StartLevel;
        public static Action FinishedLevel;
        public static Action PointsChange;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        public void AddPoint()
        {
            Points++;
            PointsChange?.Invoke();
        }

        public void ResetPoints()
        {
            Points = 0;
        }

        public void PlayerDeath()
        {
            FinishedLevel?.Invoke();
            GameObject.FindObjectOfType<LoseWindow>(true).Show();
            lineCount = 1;
        }

        public void SpawnLocation()
        {
            const int OBSTACLES_ON_START = 20;

            for (int i = 0; i < OBSTACLES_ON_START; i++)
            {
                SpawnObstacle();
            }
        }

        public void SpawnObstacle()
        {
            Vector3 obstacleSpawnPos = Vector3.right * 11 * lineCount;
            obstacleSpawnPos.y = UnityEngine.Random.Range(-4.5f, 4.5f);

            GameObject.Instantiate(obstaclePref, obstacleSpawnPos, Quaternion.identity);
            lineCount++;
        }
    }
}
