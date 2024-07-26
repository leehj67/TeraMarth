using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAppereanceAnimC : MonoBehaviour
{
    public float launchY; // �߻������� Y�� ��ǥ
    public float landingY; // ���������� Y�� ��ǥ
    public float maxHeight; // �ö� �� �ִ� �ִ� ����

    private float initialVelocity; // �ʱ� ��� �ӵ�
    private float gravity = 3.711f; // ȭ���� �߷� ���ӵ�
    private float timeToReachMaxHeight; // �ִ� ���̿� �����ϴ� �ð�
    private float timeToDescend; // �������� �ϰ��ϴ� �ð�
    private float totalTime; // �� ���� �ð�
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
            // ��Ȯ�� ���������� ��ġ ����
            transform.position = new Vector3(initialPosition.x, landingY, initialPosition.z);
            this.enabled = false; // ������ ����
        }
    }

    void CalculateFlightTimes()
    {
        // ��� �ð� ���
        timeToReachMaxHeight = Mathf.Sqrt(2 * (maxHeight - launchY) / gravity);
        initialVelocity = gravity * timeToReachMaxHeight;

        // �ϰ� �ð� ���
        float descentHeight = maxHeight - landingY;
        timeToDescend = Mathf.Sqrt(2 * descentHeight / gravity);

        totalTime = timeToReachMaxHeight + timeToDescend; // �� ���� �ð�
    }

    void UpdatePosition()
    {
        if (timeSinceStarted <= timeToReachMaxHeight)
        {
            // ��� �� ��ġ ���
            float displacementY = initialVelocity * timeSinceStarted - 0.5f * gravity * timeSinceStarted * timeSinceStarted;
            transform.position = new Vector3(initialPosition.x, launchY + displacementY, initialPosition.z);
        }
        else
        {
            // �ϰ� �� ��ġ ���
            float timeInDescend = timeSinceStarted - timeToReachMaxHeight;
            float displacementY = 0.5f * gravity * timeInDescend * timeInDescend;
            float currentY = maxHeight - displacementY;
            if (currentY < landingY) currentY = landingY; // �������� �Ʒ��� �������� �ʵ��� ����
            transform.position = new Vector3(initialPosition.x, currentY, initialPosition.z);
        }
    }
}