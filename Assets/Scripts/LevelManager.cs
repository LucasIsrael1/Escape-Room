using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    [SerializeField] private Door door;
    [SerializeField] private TMP_Text berryLabel;
    [SerializeField] private FadeOverlay fadeOverlay;
    private GameObject player;

    private int berryCount = 0;
    private int neededBerries;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        neededBerries = GameObject.FindGameObjectsWithTag("Bush").Length;
        UpdateLabel();
    }

    public void AddBerries(int count)
    {
        berryCount += count;
        UpdateLabel();
        if (berryCount >= neededBerries)
        {
            door.Open();
        }
    }

    private void UpdateLabel()
    {
        berryLabel.text = "Berries: " + berryCount + "/" + neededBerries;
    }

    public void LoadScene(String sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
    
    private IEnumerator LoadSceneAsync(String sceneName)
    {
        player.SetActive(false);
        yield return fadeOverlay.FadeOut();
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}