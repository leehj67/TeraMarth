using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeAmount = 0.7f; // �ʱ� ��鸲 ����
    public float decreaseFactor = 1.0f; // ���� �ӵ�

    private Vector3 originalPos;
    private float shakeTime = 0f;
    private float initialShakeDuration;

    void OnEnable()
    {
        originalPos = cameraTransform.localPosition;
    }

    void Update()
    {
        if (shakeTime > 0)
        {
            float currentShakeAmount = Mathf.Lerp(0, shakeAmount, shakeTime / initialShakeDuration);
            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * currentShakeAmount;
            shakeTime -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeTime = 0f;
            cameraTransform.localPosition = originalPos;
        }
    }

    public void TriggerShake(float duration)
    {
        shakeTime = duration;
        initialShakeDuration = duration;
    }
}
