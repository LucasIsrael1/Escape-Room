using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private FadeOverlay fadeOverlay;
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject levelSelectScreen;

    void Start()
    {
        ReturnToMain();
    }

    public void OpenLevelSelect()
    {
        mainScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
    }

    public void ReturnToMain()
    {
        mainScreen.SetActive(true);
        levelSelectScreen.SetActive(false);
    }

    public void LoadScene(String sceneName)
    {
        StartCoroutine(LoadSceneCorountine(sceneName));
    }
    
    private IEnumerator LoadSceneCorountine(String sceneName)
    {
        yield return fadeOverlay.FadeOut();
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}