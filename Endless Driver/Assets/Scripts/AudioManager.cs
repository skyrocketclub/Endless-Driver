using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip carStartSoundtrack;
   // public AudioClip carMotionSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = carStartSoundtrack;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!audioSource.isPlaying && !audioSource.loop && GameManager.timerActive)
        //{
        //    PlayCarMotionSound();
        //}
    }

    //private void PlayCarMotionSound()
    //{
    //    audioSource.clip = carMotionSound;
    //    audioSource.loop = true;
    //    audioSource.Play();
    //}


}
