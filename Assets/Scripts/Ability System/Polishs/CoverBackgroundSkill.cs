using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoverBackgroundSkill : MonoBehaviour
{
    public AudioClip soundSKillDontReady;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundDontReady()
    {
        audioSource.PlayOneShot(soundSKillDontReady);
    }
}
