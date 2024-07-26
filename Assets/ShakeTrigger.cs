using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    public CameraShake cameraShake;
    public float delayBeforeShake = 2.0f; // ��鸲 ���� �� ��� �ð� (��)
    public float shakeDuration = 2.0f; // ��鸮�� �ð� (��)

    private float delayTimer;
    private bool hasShaken = false;

    void Start()
    {
        delayTimer = delayBeforeShake;
    }

    void Update()
    {
        // ��� �ð� Ÿ�̸Ӱ� 0���� Ŭ �� ����
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
            // ��� �ð��� 0�� �Ǹ� ��鸲 ����
            if (delayTimer <= 0 && !hasShaken)
            {
                cameraShake.TriggerShake(shakeDuration);
                hasShaken = true;
            }
        }
    }
}
