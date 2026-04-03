using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField] private TMP_Text berryLabel;

    private int berryCount = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddBerries(int count)
    {
        berryCount += count;
        berryLabel.text = "Berries: " + berryCount;
    }
}