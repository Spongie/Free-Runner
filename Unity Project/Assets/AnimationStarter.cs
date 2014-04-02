using UnityEngine;
using System.Collections;

public class AnimationStarter : MonoBehaviour {

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Stop()
    {
        animator.SetInteger("Speed", 0);
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public void Land()
    {
        animator.SetTrigger("Land");
    }

    public void Forward()
    {
        animator.SetInteger("Speed", 1);
    }

    public void Backwards()
    {
        animator.SetInteger("Speed", -1);
    }
}
