using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour {

    Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
	}
	
    void Update () {

        if (Input.GetKey(KeyCode.W))
            animator.SetInteger("Speed", 1);
        else if (Input.GetKey(KeyCode.S))
            animator.SetInteger("Speed", -1);
        else
            animator.SetInteger("Speed", 0);
        

        Debug.Log(animator.speed);
	}
}
