using UnityEngine;

public class Spikes : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Player")) return;
        LevelManager.GameOver();
    }
}
