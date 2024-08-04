using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundFromTo : MonoBehaviour
{
    public AudioSource audioSource;
    public float startTime; // ���� �ð� (�� ����)
    public float endTime; // �� �ð� (�� ����)

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
