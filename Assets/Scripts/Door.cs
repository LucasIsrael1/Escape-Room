using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private Collider coll;

    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider>();
    }

    public void Open()
    {
        SoundManager.PlaySound("win");
        animator.SetTrigger("Open");
        coll.enabled = false;
    }
}
