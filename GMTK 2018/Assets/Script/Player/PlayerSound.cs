using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {



    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    public AudioClip jump1Sound;
    public AudioClip hurtSound;
    public AudioClip hurt2Sound;

    public AudioClip walking;
    public AudioClip gameOverSound;

    public void playAttackSound() {

        SoundManager.instance.RandomizeFx(attack1Sound, attack2Sound);
    }

    public void playhurtSound() {
        SoundManager.instance.RandomizeFx(hurtSound, hurt2Sound);

    }

    public void playWalkSound() {
        SoundManager.instance.PlaySingle(walking);
    }

    public void playJumpSound()
    {
        SoundManager.instance.PlaySingle(jump1Sound);
    }
}
