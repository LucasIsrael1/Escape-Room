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
        animator.SetTrigger("Open");
        coll.enabled = false;
    }

    public void Close()
    {
        animator.SetTrigger("Close");
        coll.enabled = true;
    }
}
