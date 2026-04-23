using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private SwitchController controller;
    
    [SerializeField] private Material offMaterial;
    [SerializeField] private Material onMaterial;
    [SerializeField] private MeshRenderer meshRenderer;

    private HashSet<GameObject> overlappingObjects = new HashSet<GameObject>();

    void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;
        if (!obj.CompareTag("Box")) return;
        overlappingObjects.Add(obj);
        if (overlappingObjects.Count == 1)
        {
            controller.SwitchPressed();
            meshRenderer.material = onMaterial;
        }
    }
        
     void OnTriggerExit(Collider collider)
    {
        GameObject obj = collider.gameObject;
        if (!obj.CompareTag("Box")) return;
        overlappingObjects.Remove(obj);
            if (overlappingObjects.Count == 0)
            {
                controller.SwitchUnpressed();
                meshRenderer.material = offMaterial;
        }
    }
}
