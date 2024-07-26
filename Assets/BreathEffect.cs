using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreatheEffect : MonoBehaviour
{
    public Transform targetTransform;
    public float minDuration = 1.0f; // �ּ� �ִϸ��̼� �ð�
    public float maxDuration = 3.0f; // �ִ� �ִϸ��̼� �ð�
    public float delayBeforeBreathe = 2.0f; // ���� ȿ�� ���� �� ��� �ð� (��)
    public float maxSize = 2.0f; // �ִ� ũ��
    public float minSize = 0.1f; // �ּ� ũ��

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
