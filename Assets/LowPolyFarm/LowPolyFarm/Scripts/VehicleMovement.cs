using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Transform[] targets; // 목표 위치를 가진 Transform 배열
    public int currentTargetIndex = 0; // 현재 목표 위치의 인덱스
    public float speed = 1.0f; // 이동 속도
    public float rotationSpeed = 1.0f; // 회전 속도

    private bool isMoving = false;

    void Update()
    {
        if (isMoving && targets.Length > 0)
        {
            Transform currentTarget = targets[currentTargetIndex];

            // 목표 위치로 부드럽게 이동
            transform.position = Vector3.Lerp(transform.position, currentTarget.position, speed * Time.deltaTime);

            // 목표를 바라보도록 부드럽게 회전
            Quaternion targetRotation = Quaternion.LookRotation(currentTarget.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 목표 위치에 충분히 가까워졌는지 체크
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
            {
                currentTargetIndex = (currentTargetIndex + 1) % targets.Length; // 다음 목표로 인덱스 업데이트
            }
        }
    }

    // 외부에서 이 함수를 호출하여 이동을 시작
    public void StartMoving()
    {
        if (targets.Length > 0) // 목표가 설정되어 있으면
        {
            isMoving = true;
        }
        else
        {
            Debug.LogError("No targets set in the inspector!");
        }
    }
}
