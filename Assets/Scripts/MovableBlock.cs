using UnityEngine;
using System.Collections;

public class MovableBlock : MonoBehaviour
{
    [SerializeField] private Vector3 activePosition;
    [SerializeField] private float duration = 0.5f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Activate()
    {
        StopAllCoroutines();
        StartCoroutine(Move(activePosition));
    }

    public void Deactivate()
    {
        StopAllCoroutines();
        StartCoroutine(Move(initialPosition));
    }

    private IEnumerator Move(Vector3 target)
    {
        Vector3 start = transform.position;
        float time = 0;
        while (time <= duration)
        {
            transform.position = Vector3.Lerp(start, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
    }
}
