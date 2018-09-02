using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource fxSound;
    public AudioSource musicSound;

    public static SoundManager instance = null;



    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if(instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}

    public void PlaySingle(AudioClip clip) {
        if (!fxSound.isPlaying)
        {
            fxSound.clip = clip;
            fxSound.PlayOneShot(clip);
        }
    }

    public void RandomizeFx(params AudioClip[] clips)
    {
        if (!fxSound.isPlaying) {
            int randomIndex = Random.Range(0, clips.Length);
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            fxSound.pitch = randomPitch;
            fxSound.clip = clips[randomIndex];
            fxSound.PlayOneShot(clips[randomIndex]);
        }

    }

}
