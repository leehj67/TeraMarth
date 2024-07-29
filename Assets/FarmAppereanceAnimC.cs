using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAppearanceAnimC : MonoBehaviour
{
    public GameObject[] objectsToAnimate; // 애니메이션할 객체들
    public float launchYOffset; // 발사지점의 Y축 오프셋
    public float landingYOffset; // 착륙지점의 Y축 오프셋
    public float maxHeightOffset; // 최대 높이 오프셋
    public float sizeMultiplier = 1f; // 크기 배율

    private float initialVelocity; // 초기 상승 속도
    private float gravity = 3.711f; // 화성의 중력 가속도
    private float timeToReachMaxHeight; // 최대 높이에 도달하는 시간
    private float timeToDescend; // 착륙까지 하강하는 시간
    private float totalTime; // 총 비행 시간
    private float timeSinceStarted;

    private Vector3[] initialPositions;
    private Vector3[] initialScales;

    void Start()
    {
        initialPositions = new Vector3[objectsToAnimate.Length];
        initialScales = new Vector3[objectsToAnimate.Length];

        for (int i = 0; i < objectsToAnimate.Length; i++)
        {
            GameObject obj = objectsToAnimate[i];
            initialPositions[i] = obj.transform.position;
            initialScales[i] = obj.transform.localScale;
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + launchYOffset, obj.transform.position.z);
        }

        CalculateFlightTimes();
    }

    void Update()
    {
        timeSinceStarted += Time.deltaTime;
        if (timeSinceStarted <= totalTime)
        {
            UpdatePositions();
        }
        else
        {
            // 정확한 착륙지점에 위치 고정
            for (int i = 0; i < objectsToAnimate.Length; i++)
            {
                GameObject obj = objectsToAnimate[i];
                obj.transform.position = new Vector3(initialPositions[i].x, initialPositions[i].y + landingYOffset, initialPositions[i].z);
                obj.transform.localScale = initialScales[i] * sizeMultiplier;
            }
            this.enabled = false; // 움직임 멈춤
        }
    }

    void CalculateFlightTimes()
    {
        // 상승 시간 계산
        timeToReachMaxHeight = Mathf.Sqrt(2 * maxHeightOffset / gravity);
        initialVelocity = gravity * timeToReachMaxHeight;

        // 하강 시간 계산
        float descentHeight = maxHeightOffset - landingYOffset;
        timeToDescend = Mathf.Sqrt(2 * descentHeight / gravity);

        totalTime = timeToReachMaxHeight + timeToDescend; // 총 비행 시간
    }

    void UpdatePositions()
    {
        for (int i = 0; i < objectsToAnimate.Length; i++)
        {
            GameObject obj = objectsToAnimate[i];
            Vector3 initialPosition = initialPositions[i];
            Vector3 initialScale = initialScales[i];

            if (timeSinceStarted <= timeToReachMaxHeight)
            {
                // 상승 중 위치 계산
                float displacementY = initialVelocity * timeSinceStarted - 0.5f * gravity * timeSinceStarted * timeSinceStarted;
                obj.transform.position = new Vector3(initialPosition.x, initialPosition.y + launchYOffset + displacementY, initialPosition.z);
            }
            else
            {
                // 하강 중 위치 계산
                float timeInDescend = timeSinceStarted - timeToReachMaxHeight;
                float displacementY = 0.5f * gravity * timeInDescend * timeInDescend;
                float currentY = initialPosition.y + launchYOffset + maxHeightOffset - displacementY;
                if (currentY < initialPosition.y + landingYOffset) currentY = initialPosition.y + landingYOffset; // 착륙지점 아래로 내려가지 않도록 보정
                obj.transform.position = new Vector3(initialPosition.x, currentY, initialPosition.z);
            }

            // 크기 조절
            float scaleMultiplier = Mathf.Lerp(1f, sizeMultiplier, timeSinceStarted / totalTime);
            obj.transform.localScale = initialScale * scaleMultiplier;
        }
    }
}
