using UnityEngine;
using Unity.VisualScripting;
using System;
using System.Collections.Generic;

public class Switch : MonoBehaviour
{
    [SerializeField] private SwitchController controller;

    private HashSet<GameObject> overlappingObjects = new HashSet<GameObject>();

    void OnTriggerEnter(Collider collider)
    {
        GameObject obj = collider.gameObject;
        if (!obj.CompareTag("Player") && !obj.CompareTag("Box")) return;
        overlappingObjects.Add(obj);
        if (overlappingObjects.Count == 1) controller.SwitchPressed();
    }

    void OnTriggerExit(Collider collider)
    {
        GameObject obj = collider.gameObject;
        if (!obj.CompareTag("Player") && !obj.CompareTag("Box")) return;
        overlappingObjects.Remove(obj);
        if (overlappingObjects.Count == 0) controller.SwitchUnpressed();
    }
}
