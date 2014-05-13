using UnityEngine;
using System.Collections;

public class CharacterSoundPlayer : MonoBehaviour {

    AudioSource audio;

	void Start () {
        audio = GetComponent<AudioSource>();
	}

    public void PlayFootstep()
    {
        audio.Play();
    }
}
