using UnityEngine;
using System.Collections;

public class CharacterMover : MonoBehaviour {

    CharacterController controller;
    Vector3 totalMove;

	void Start () {
        controller = GetComponent<CharacterController>();
	}

    public void AddMovement(Vector3 movement)
    {
        totalMove += movement;
    }

	void Update () {
        totalMove = Vector3.zero;
        AddMovement(new Vector3(0, 0.92f, 0));
        controller.Move(totalMove * Time.deltaTime);
	}
}
