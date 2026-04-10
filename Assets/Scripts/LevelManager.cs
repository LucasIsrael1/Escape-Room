using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    
    [SerializeField] private Door door;
    [SerializeField] private TMP_Text berryLabel;

    private int berryCount = 0;
    private int neededBerries;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
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
}