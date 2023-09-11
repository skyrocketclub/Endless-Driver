using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayRandomMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public int musicIndex = 0;
    public AudioClip[] soundTracks;
    public static bool changeMusic = false;
    public static bool changeIncomingTrack = false;
    public TextMeshProUGUI nowPlaying;
    public TextMeshProUGUI incomingTrack;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(changeMusic == true)
        {
            changeMusic = false;
            //audioSource.Stop();
            ChangeMusic();
        }
        if (!GameManager.timerActive)
        {
            audioSource.Stop();
        }
        if (changeIncomingTrack) 
        {
            //Time to change the incoming track  text
            changeIncomingTrack = false;
            UpdateMusicIndex();
        }
    }

    private void ChangeMusic()
    {
        Debug.Log("New Music Played...");
        audioSource.clip = soundTracks[musicIndex];
        audioSource.Play();
        audioSource.loop = true;
        if (!nowPlaying.gameObject.activeSelf) // To check if the "now playing" text is not active and activate it...
        {
            nowPlaying.gameObject.SetActive(true);
        }
        UpdateNowPlaying();
        //incomingTrack.gameObject.SetActive(false); //make the incoming track inactive since there is no incoming track...
    }

    public void UpdateNowPlaying()
    {
        string currentMusic = "Now Playing: " + soundTracks[musicIndex].name;
        nowPlaying.text = currentMusic;
    }

    public void UpdateIncomingTrack()
    {
        string currentMusic = "Incoming Track: " + soundTracks[musicIndex].name;
        incomingTrack.text = currentMusic;
    }

    public void UpdateMusicIndex()
    {
        musicIndex = Random.Range(0, soundTracks.Length);
        incomingTrack.gameObject.SetActive(true); //Making the incoming track text to be active { Make this timed }...
        StartCoroutine(InactiveTextCountdownRoutine());
        UpdateIncomingTrack();
    }

    IEnumerator InactiveTextCountdownRoutine()
    {
        //Make the incoming track inactive after 3 seconds...
        yield return new WaitForSeconds(3);
        incomingTrack.gameObject.SetActive(false);
    }

}
