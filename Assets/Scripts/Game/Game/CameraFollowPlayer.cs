using System.Collections;
using System.Collections.Generic;
using Core.State;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Player player;
    private float speed = 0.125f;
    private bool isLevelStarted = false;

    private void Awake() /// ??
    {
        LevelController.StartLevel += OnStartLevel;
    }

    private void OnDestroy()
    {
        LevelController.StartLevel -= OnStartLevel;
    }

    private void OnStartLevel()
    {
        isLevelStarted = true;
    }

    private void FixedUpdate()
    {
        if (isLevelStarted == true)
        {
            if (player != null)
            {
                Vector3 desiredPosition = new Vector3(player.gameObject.transform.position.x, transform.position.y, transform.position.z);

                transform.position = Vector3.Lerp(transform.position, desiredPosition, speed);
            }
        }
    }
}
