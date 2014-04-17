using UnityEngine;
using System.Collections;

public class LandChecker : MonoBehaviour {


    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.tag == "Ground")
            GetComponent<AnimationStarter>().Land();
    }
}
