using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundFromTo : MonoBehaviour
{
    public AudioSource audioSource;
    public float startTime; // 시작 시간 (초 단위)
    public float endTime; // 끝 시간 (초 단위)

    private bool isPlaying;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource != null)
        {
            audioSource.time = startTime;
            audioSource.Play();
            isPlaying = true;
        }
    }

    void Update()
    {
        if (isPlaying && audioSource.time >= endTime)
        {
            audioSource.Stop();
            isPlaying = false;
        }
    }
}
