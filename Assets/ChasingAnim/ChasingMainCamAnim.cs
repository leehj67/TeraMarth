using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingMainCamAnim : MonoBehaviour
{
    public float duration = 2.0f;  // ���� ���� �ð�
    public float maxMagnitude = 0.1f; // �ִ� ���� ����
    public float startDelay = 5.0f;  // ���� ���� �� ��� �ð�

    private bool isShaking = false;
    private float delayTimer;

    void Start()
    {
        delayTimer = startDelay;  // ��� �ð� Ÿ�̸� �ʱ�ȭ
    }

    void Update()
    {
        if (!isShaking)
        {
            // ��� �ð� ����
            delayTimer -= Time.deltaTime;

            // ��� �ð��� ������ ���� ����
            if (delayTimer <= 0)
            {
                StartCoroutine(Shake(duration, maxMagnitude));
                isShaking = true;  // ���� ���·� ����
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
        delayTimer = startDelay;  // ��� �ð� �ٽ� ����, �ʿ信 ���� �ݺ����� ������ ����
    }
}