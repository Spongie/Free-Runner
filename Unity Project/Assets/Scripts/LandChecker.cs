using UnityEngine;
using System.Collections;

public class LandChecker : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if(GetComponent<CharacterController>().isGrounded)
           GetComponent<AnimationStarter>().Land();
    }
}
