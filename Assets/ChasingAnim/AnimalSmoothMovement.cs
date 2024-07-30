using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSmoothMovement : MonoBehaviour
{
    public Vector2 targetPosition; // 목표 X, Z 위치
    public float duration = 5.0f;  // 이동 지속 시간

    private Vector2 startPosition; // 시작 위치
    private float timeElapsed;     // 경과 시간

    void Start()
    {
        // 시작 위치를 현재 게임 오브젝트의 위치에서 X, Z 좌표로 설정
        startPosition = new Vector2(transform.position.x, transform.position.z);
        timeElapsed = 0f; // 경과 시간 초기화
    }

    void Update()
    {
        if (timeElapsed < duration)
        {
            // 경과 시간 업데이트
            timeElapsed += Time.deltaTime;
            float lerpFactor = timeElapsed / duration; // 선형 보간 계수 계산

            // 새 위치 계산
            float newX = Mathf.Lerp(startPosition.x, targetPosition.x, lerpFactor);
            float newZ = Mathf.Lerp(startPosition.y, targetPosition.y, lerpFactor);

            // 게임 오브젝트 위치 업데이트
            transform.position = new Vector3(newX, transform.position.y, newZ);
        }
    }
}