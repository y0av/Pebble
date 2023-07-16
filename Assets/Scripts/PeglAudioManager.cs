using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeglAudioManager : MonoBehaviour
{
    public int pitchMultiplier = 100;
    public float startingPitch = 0.25f;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Hit(int pitch)
    {
        float normalizedPitch = (float)pitch / pitchMultiplier + startingPitch;
        audioSource.pitch = normalizedPitch;
        audioSource.Play();
    }
}
