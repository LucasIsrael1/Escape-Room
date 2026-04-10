using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] private FadeOverlay fadeOverlay;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (string.IsNullOrEmpty(nextLevel) || !collider.gameObject.CompareTag("Player")) return;

        player.SetActive(false);
        StartCoroutine(TransitionScene());
    }

    private IEnumerator TransitionScene()
    {
        yield return fadeOverlay.FadeOut();
        yield return SceneManager.LoadSceneAsync(nextLevel);
    }
}