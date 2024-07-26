using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFlame : MonoBehaviour
{
    public Transform flameTransform;
    public float minDuration = 0.05f; // �ּ� �ִϸ��̼� �ð�
    public float maxDuration = 0.15f; // �ִ� �ִϸ��̼� �ð�
    public float minYPosition = -1.0f; // �ּ� Y�� ��ġ
    public float maxYPosition = 1.0f; // �ִ� Y�� ��ġ
    public float lightIntensity = 1.0f; // ���� ����

    private Vector3 initialPosition;
    private float duration;
    private float timer = 0.0f;
    private Light flameLight;

    void Start()
    {
        initialPosition = flameTransform.localPosition;
        SetRandomDuration();

        // �� ������Ʈ �߰�
        flameLight = gameObject.AddComponent<Light>();
        flameLight.type = LightType.Point;
        flameLight.intensity = lightIntensity;
        flameLight.range = 5.0f; // ���� ���� ����
        flameLight.color = Color.yellow; // ���� ���� ����
    }

    void Update()
    {
        timer += Time.deltaTime;
        float halfDuration = duration / 2.0f;

        float progress = timer / halfDuration;

        if (timer <= halfDuration)
        {
            float yPos = Mathf.Lerp(minYPosition, maxYPosition, progress);
            flameTransform.localPosition = new Vector3(initialPosition.x, initialPosition.y + yPos, initialPosition.z);
        }
        else if (timer <= duration)
        {
            float yPos = Mathf.Lerp(maxYPosition, minYPosition, progress - 1);
            flameTransform.localPosition = new Vector3(initialPosition.x, initialPosition.y + yPos, initialPosition.z);
        }
        else
        {
            timer = 0.0f;
            SetRandomDuration();
        }
    }

    void SetRandomDuration()
    {
        duration = Random.Range(minDuration, maxDuration);
    }
}
