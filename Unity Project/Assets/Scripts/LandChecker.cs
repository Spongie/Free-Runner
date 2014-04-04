using UnityEngine;
using System.Collections;

public class LandChecker : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            GetComponent<AnimationStarter>().Land();
    }
}
