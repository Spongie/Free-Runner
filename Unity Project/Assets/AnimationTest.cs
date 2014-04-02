using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour {

    Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
	}
	
    void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("Speed", 1);
            transform.Translate(transform.forward * 10);
        }
        else if (Input.GetKey(KeyCode.S))
            animator.SetInteger("Speed", -1);
        else
            animator.SetInteger("Speed", 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("LaaAANDED");
        if (collision.gameObject.tag == "Ground")
            animator.SetTrigger("Land");
    }
}
