using UnityEngine;

public class BerryBush : MonoBehaviour
{
    [SerializeField] private bool hasBerries = true;

    [SerializeField] private Material baseMaterial;
    [SerializeField] private Material berriesMaterial;
    [SerializeField] private GameObject model;
    private Renderer[] renderers;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        updateMaterial(hasBerries ? berriesMaterial : baseMaterial);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!hasBerries || !collider.gameObject.CompareTag("Player")) return;
        hasBerries = false;
        updateMaterial(baseMaterial);
        LevelManager.instance.AddBerries(1);
    }

    private void updateMaterial(Material material)
    {
        foreach (Renderer rend in renderers)
        {
            rend.material = material;
        }
    } 
}