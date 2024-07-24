using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreatheEffect : MonoBehaviour
{
    public Transform targetTransform;
    public float minDuration = 1.0f; // 최소 애니메이션 시간
    public float maxDuration = 3.0f; // 최대 애니메이션 시간
    public float delayBeforeBreathe = 2.0f; // 연기 효과 시작 전 대기 시간 (초)
    public float maxSize = 2.0f; // 최대 크기
    public float minSize = 0.1f; // 최소 크기

    private Vector3 initialScale;
    private float duration;
    private float timer = 0.0f;
    private float delayTimer = 0.0f;
    private bool isTriggered = false;

    void Start()
    {
        initialScale = targetTransform.localScale;
        SetRandomDuration();
        delayTimer = delayBeforeBreathe;
    }

    void Update()
    {
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0)
            {
                isTriggered = true;
                timer = 0.0f;
            }
        }

        if (isTriggered)
        {
            timer += Time.deltaTime;
            float halfDuration = duration / 2.0f;

            float progress = timer / halfDuration;

            if (timer <= halfDuration)
            {
                targetTransform.localScale = Vector3.Lerp(initialScale * minSize, initialScale * maxSize, progress);
            }
            else if (timer <= duration)
            {
                targetTransform.localScale = Vector3.Lerp(initialScale * maxSize, initialScale * minSize, progress - 1);
            }
            else
            {
                timer = 0.0f;
                SetRandomDuration();
                delayTimer = delayBeforeBreathe;
                isTriggered = false;
            }
        }
    }

    void SetRandomDuration()
    {
        duration = Random.Range(minDuration, maxDuration);
    }
}
