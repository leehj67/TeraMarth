using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFlame : MonoBehaviour
{
    public Transform flameTransform;
    public float minDuration = 0.05f; // 최소 애니메이션 시간
    public float maxDuration = 0.15f; // 최대 애니메이션 시간
    public float minYPosition = -1.0f; // 최소 Y축 위치
    public float maxYPosition = 1.0f; // 최대 Y축 위치
    public float lightIntensity = 1.0f; // 빛의 강도

    private Vector3 initialPosition;
    private float duration;
    private float timer = 0.0f;
    private Light flameLight;

    void Start()
    {
        initialPosition = flameTransform.localPosition;
        SetRandomDuration();

        // 빛 컴포넌트 추가
        flameLight = gameObject.AddComponent<Light>();
        flameLight.type = LightType.Point;
        flameLight.intensity = lightIntensity;
        flameLight.range = 5.0f; // 빛의 범위 설정
        flameLight.color = Color.yellow; // 빛의 색상 설정
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
