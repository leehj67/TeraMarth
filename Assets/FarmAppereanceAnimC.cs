using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAppereanceAnimC : MonoBehaviour
{
    public float launchY; // 발사지점의 Y축 좌표
    public float landingY; // 착륙지점의 Y축 좌표
    public float maxHeight; // 올라갈 수 있는 최대 높이

    private float initialVelocity; // 초기 상승 속도
    private float gravity = 3.711f; // 화성의 중력 가속도
    private float timeToReachMaxHeight; // 최대 높이에 도달하는 시간
    private float timeToDescend; // 착륙까지 하강하는 시간
    private float totalTime; // 총 비행 시간
    private float timeSinceStarted;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = new Vector3(transform.position.x, launchY, transform.position.z);
        transform.position = initialPosition;
        CalculateFlightTimes();
    }

    void Update()
    {
        timeSinceStarted += Time.deltaTime;
        if (timeSinceStarted <= totalTime)
        {
            UpdatePosition();
        }
        else
        {
            // 정확한 착륙지점에 위치 고정
            transform.position = new Vector3(initialPosition.x, landingY, initialPosition.z);
            this.enabled = false; // 움직임 멈춤
        }
    }

    void CalculateFlightTimes()
    {
        // 상승 시간 계산
        timeToReachMaxHeight = Mathf.Sqrt(2 * (maxHeight - launchY) / gravity);
        initialVelocity = gravity * timeToReachMaxHeight;

        // 하강 시간 계산
        float descentHeight = maxHeight - landingY;
        timeToDescend = Mathf.Sqrt(2 * descentHeight / gravity);

        totalTime = timeToReachMaxHeight + timeToDescend; // 총 비행 시간
    }

    void UpdatePosition()
    {
        if (timeSinceStarted <= timeToReachMaxHeight)
        {
            // 상승 중 위치 계산
            float displacementY = initialVelocity * timeSinceStarted - 0.5f * gravity * timeSinceStarted * timeSinceStarted;
            transform.position = new Vector3(initialPosition.x, launchY + displacementY, initialPosition.z);
        }
        else
        {
            // 하강 중 위치 계산
            float timeInDescend = timeSinceStarted - timeToReachMaxHeight;
            float displacementY = 0.5f * gravity * timeInDescend * timeInDescend;
            float currentY = maxHeight - displacementY;
            if (currentY < landingY) currentY = landingY; // 착륙지점 아래로 내려가지 않도록 보정
            transform.position = new Vector3(initialPosition.x, currentY, initialPosition.z);
        }
    }
}