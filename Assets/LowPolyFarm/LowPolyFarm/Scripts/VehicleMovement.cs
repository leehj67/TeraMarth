using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Transform[] targets; // ��ǥ ��ġ�� ���� Transform �迭
    public int currentTargetIndex = 0; // ���� ��ǥ ��ġ�� �ε���
    public float speed = 1.0f; // �̵� �ӵ�
    public float rotationSpeed = 1.0f; // ȸ�� �ӵ�

    private bool isMoving = false;

    void Update()
    {
        if (isMoving && targets.Length > 0)
        {
            Transform currentTarget = targets[currentTargetIndex];

            // ��ǥ ��ġ�� �ε巴�� �̵�
            transform.position = Vector3.Lerp(transform.position, currentTarget.position, speed * Time.deltaTime);

            // ��ǥ�� �ٶ󺸵��� �ε巴�� ȸ��
            Quaternion targetRotation = Quaternion.LookRotation(currentTarget.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // ��ǥ ��ġ�� ����� ����������� üũ
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
            {
                currentTargetIndex = (currentTargetIndex + 1) % targets.Length; // ���� ��ǥ�� �ε��� ������Ʈ
            }
        }
    }

    // �ܺο��� �� �Լ��� ȣ���Ͽ� �̵��� ����
    public void StartMoving()
    {
        if (targets.Length > 0) // ��ǥ�� �����Ǿ� ������
        {
            isMoving = true;
        }
        else
        {
            Debug.LogError("No targets set in the inspector!");
        }
    }
}
