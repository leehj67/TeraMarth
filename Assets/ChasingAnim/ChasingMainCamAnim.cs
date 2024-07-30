using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingMainCamAnim : MonoBehaviour
{
    public float duration = 2.0f;  // 진동 지속 시간
    public float maxMagnitude = 0.1f; // 최대 진동 강도
    public float startDelay = 5.0f;  // 진동 시작 전 대기 시간

    private bool isShaking = false;
    private float delayTimer;

    void Start()
    {
        delayTimer = startDelay;  // 대기 시간 타이머 초기화
    }

    void Update()
    {
        if (!isShaking)
        {
            // 대기 시간 감소
            delayTimer -= Time.deltaTime;

            // 대기 시간이 끝나면 진동 시작
            if (delayTimer <= 0)
            {
                StartCoroutine(Shake(duration, maxMagnitude));
                isShaking = true;  // 진동 상태로 설정
            }
        }
    }

    IEnumerator Shake(float duration, float maxMagnitude)
    {
        float halfDuration = duration / 2f;
        float timer = 0.0f;
        Vector3 originalPos = transform.localPosition;

        while (timer < duration)
        {
            float currentMagnitude = Mathf.Lerp(0f, maxMagnitude, timer < halfDuration ? timer / halfDuration : (duration - timer) / halfDuration);
            float x = Random.Range(-1f, 1f) * currentMagnitude;
            float y = Random.Range(-1f, 1f) * currentMagnitude;

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            timer += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        isShaking = false;
        delayTimer = startDelay;  // 대기 시간 다시 설정, 필요에 따라 반복적인 진동을 위해
    }
}