using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip beepSound;

    void Start()
    {
        audioSource.PlayOneShot(beepSound);
    }
}
