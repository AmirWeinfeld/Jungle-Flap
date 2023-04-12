using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] myMusic; // declare this as Object array

    private int currentSongIndex;

    void Awake()
    {
        currentSongIndex = 0;
        audioSource.clip = myMusic[0];
    }

    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
            PlayNextSong();
    }

    public void PlayNextSong()
    {
        currentSongIndex += 1;
        if (currentSongIndex == myMusic.Length)
        {
            currentSongIndex = 0;
        }

        audioSource.clip = myMusic[currentSongIndex];
        audioSource.Play();
    }
}
