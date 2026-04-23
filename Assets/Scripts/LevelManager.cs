using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    
    [SerializeField] private Door door;
    [SerializeField] private TMP_Text berryLabel;
    [SerializeField] private FadeOverlay fadeOverlay;
    [SerializeField] private GameOverSystem gameOver;
    private GameObject player;

    private int berryCount = 0;
    private int neededBerries;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        neededBerries = GameObject.FindGameObjectsWithTag("Bush").Length;
        UpdateLabel();
    }

    public static void AddBerries(int count)
    {
        instance.berryCount += count;
        instance.UpdateLabel();
        if (instance.berryCount >= instance.neededBerries)
        {
            instance.door.Open();
        }
    }

    private void UpdateLabel()
    {
        berryLabel.text = "Berries: " + berryCount + "/" + neededBerries;
    }

    public static void LoadScene(String sceneName)
    {
        instance.StartCoroutine(instance.LoadSceneCorountine(sceneName));
    }
    
    private IEnumerator LoadSceneCorountine(String sceneName)
    {
        player.SetActive(false);
        yield return fadeOverlay.FadeOut();
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

    public static void GameOver() {
        instance.gameOver.GameOver();
    }
}