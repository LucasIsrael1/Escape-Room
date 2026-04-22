using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] public static LevelTransition instance;

    void OnTriggerEnter(Collider collider)
    {
        if (string.IsNullOrEmpty(nextLevel) || !collider.gameObject.CompareTag("Player")) return;
        LevelManager.instance.LoadScene(nextLevel);
    }
}