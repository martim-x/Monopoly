using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    [SerializeField] AudioClip[] playlist;
    AudioSource source;
    int startTrack;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        startTrack = Random.Range(0, playlist.Length);
        source.clip = playlist[startTrack];
        source.PlayDelayed(1.5f);
    }
    private void Update()
    {
        if (!source.isPlaying)
        {
            if (startTrack >= playlist.Length - 1)
            {
                startTrack = 0;
            }
            else
            {
                startTrack++;
            }
            source.clip = playlist[startTrack];
            source.PlayDelayed(2f);
        }
    }
}
