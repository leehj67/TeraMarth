using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource1; // 첫 번째 오디오 소스
    public AudioSource audioSource2; // 두 번째 오디오 소스
    public float playTime = 5.0f; // 첫 번째 소리를 재생할 시간 (초)

    void Start()
    {
        StartCoroutine(PlayAudioWithDelay());
    }

    IEnumerator PlayAudioWithDelay()
    {
        // 첫 번째 오디오 소스 재생
        audioSource1.Play();
        
        // 지정된 시간 동안 대기
        yield return new WaitForSeconds(playTime);
        
        // 첫 번째 오디오 소스 정지
        audioSource1.Stop();
        
        // 두 번째 오디오 소스 재생
        audioSource2.Play();
    }
}
