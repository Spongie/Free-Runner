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
        Debug.Log("Original. " + totalMove);
        totalMove += movement;
        Debug.Log("Af´ter: " + totalMove);
    }

	void Update () {
        totalMove = Vector3.zero;
        AddMovement(new Vector3(0, -9.92f, 0));
        Debug.Log("moving with power: " + totalMove);
        controller.Move(totalMove * Time.deltaTime);
	}
}
