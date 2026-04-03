using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private TMP_Text berryLabel;
    [SerializeField] private LevelDoor door;

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