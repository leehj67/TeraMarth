using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAppearanceAnimC : MonoBehaviour
{
    public GameObject[] objectsToAnimate; // �ִϸ��̼��� ��ü��
    public float launchYOffset; // �߻������� Y�� ������
    public float landingYOffset; // ���������� Y�� ������
    public float maxHeightOffset; // �ִ� ���� ������
    public float sizeMultiplier = 1f; // ũ�� ����

    private float initialVelocity; // �ʱ� ��� �ӵ�
    private float gravity = 3.711f; // ȭ���� �߷� ���ӵ�
    private float timeToReachMaxHeight; // �ִ� ���̿� �����ϴ� �ð�
    private float timeToDescend; // �������� �ϰ��ϴ� �ð�
    private float totalTime; // �� ���� �ð�
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
            // ��Ȯ�� ���������� ��ġ ����
            for (int i = 0; i < objectsToAnimate.Length; i++)
            {
                GameObject obj = objectsToAnimate[i];
                obj.transform.position = new Vector3(initialPositions[i].x, initialPositions[i].y + landingYOffset, initialPositions[i].z);
                obj.transform.localScale = initialScales[i] * sizeMultiplier;
            }
            this.enabled = false; // ������ ����
        }
    }

    void CalculateFlightTimes()
    {
        // ��� �ð� ���
        timeToReachMaxHeight = Mathf.Sqrt(2 * maxHeightOffset / gravity);
        initialVelocity = gravity * timeToReachMaxHeight;

        // �ϰ� �ð� ���
        float descentHeight = maxHeightOffset - landingYOffset;
        timeToDescend = Mathf.Sqrt(2 * descentHeight / gravity);

        totalTime = timeToReachMaxHeight + timeToDescend; // �� ���� �ð�
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
                // ��� �� ��ġ ���
                float displacementY = initialVelocity * timeSinceStarted - 0.5f * gravity * timeSinceStarted * timeSinceStarted;
                obj.transform.position = new Vector3(initialPosition.x, initialPosition.y + launchYOffset + displacementY, initialPosition.z);
            }
            else
            {
                // �ϰ� �� ��ġ ���
                float timeInDescend = timeSinceStarted - timeToReachMaxHeight;
                float displacementY = 0.5f * gravity * timeInDescend * timeInDescend;
                float currentY = initialPosition.y + launchYOffset + maxHeightOffset - displacementY;
                if (currentY < initialPosition.y + landingYOffset) currentY = initialPosition.y + landingYOffset; // �������� �Ʒ��� �������� �ʵ��� ����
                obj.transform.position = new Vector3(initialPosition.x, currentY, initialPosition.z);
            }

            // ũ�� ����
            float scaleMultiplier = Mathf.Lerp(1f, sizeMultiplier, timeSinceStarted / totalTime);
            obj.transform.localScale = initialScale * scaleMultiplier;
        }
    }
}
