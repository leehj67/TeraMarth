using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSmoothMovement : MonoBehaviour
{
    public Vector2 targetPosition; // ��ǥ X, Z ��ġ
    public float duration = 5.0f;  // �̵� ���� �ð�

    private Vector2 startPosition; // ���� ��ġ
    private float timeElapsed;     // ��� �ð�

    void Start()
    {
        // ���� ��ġ�� ���� ���� ������Ʈ�� ��ġ���� X, Z ��ǥ�� ����
        startPosition = new Vector2(transform.position.x, transform.position.z);
        timeElapsed = 0f; // ��� �ð� �ʱ�ȭ
    }

    void Update()
    {
        if (timeElapsed < duration)
        {
            // ��� �ð� ������Ʈ
            timeElapsed += Time.deltaTime;
            float lerpFactor = timeElapsed / duration; // ���� ���� ��� ���

            // �� ��ġ ���
            float newX = Mathf.Lerp(startPosition.x, targetPosition.x, lerpFactor);
            float newZ = Mathf.Lerp(startPosition.y, targetPosition.y, lerpFactor);

            // ���� ������Ʈ ��ġ ������Ʈ
            transform.position = new Vector3(newX, transform.position.y, newZ);
        }
    }
}