using System.Collections;
using System.Collections.Generic;
using Core.Game;
using Core.State;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float forceJump = 7f;
    private Rigidbody2D rb;
    private bool isLevelStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void Awake() /// ???
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

    // Update is called once per frame
    void Update()
    {
        if (isLevelStarted == true)
        {
            transform.Translate(Vector2.right * 2f * Time.deltaTime);
            rb.isKinematic = false;
            if (Input.GetMouseButtonDown(0))
            {
                PlayerJump();
            }
            if (gameObject.transform.position.y <= -10 || gameObject.transform.position.y >= 10)
            {
                Death();
            }
        }
    }
    private void PlayerJump()
    {
        rb.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
    }

    private void Death()
    {
        Destroy(gameObject);
        LevelController.Instance.PlayerDeath();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LevelController.Instance.AddPoint();
        LevelController.Instance.SpawnObstacle();
    }
}
