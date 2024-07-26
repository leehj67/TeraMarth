using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    public CameraShake cameraShake;
    public float delayBeforeShake = 2.0f; // 흔들림 시작 전 대기 시간 (초)
    public float shakeDuration = 2.0f; // 흔들리는 시간 (초)

    private float delayTimer;
    private bool hasShaken = false;

    void Start()
    {
        delayTimer = delayBeforeShake;
    }

    void Update()
    {
        // 대기 시간 타이머가 0보다 클 때 감소
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
            // 대기 시간이 0이 되면 흔들림 시작
            if (delayTimer <= 0 && !hasShaken)
            {
                cameraShake.TriggerShake(shakeDuration);
                hasShaken = true;
            }
        }
    }
}
