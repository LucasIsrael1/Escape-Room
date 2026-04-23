using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverSystem : MonoBehaviour
{
    public static GameOverSystem instance;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private FadeOverlay fadeOverlay;
    private GameObject player;

    void Start()
    {
        instance = this;
        gameOverScreen.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void GameOver()
    {
        player.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        gameOverScreen.SetActive(false);
        LevelManager.instance.LoadScene(SceneManager.GetActiveScene().name);
    }
}
