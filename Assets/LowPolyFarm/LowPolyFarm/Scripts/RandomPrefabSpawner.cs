using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // ������ ������ �迭
    public int numberOfObjects = 10; // ������ ������Ʈ�� ��
    public Vector3 spawnArea; // ���� ����

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            ) + transform.position;

            GameObject selectedPrefab = prefabs[Random.Range(0, prefabs.Length)];
            GameObject instance = Instantiate(selectedPrefab, randomPosition, Quaternion.identity, transform);

            // �θ� ������Ʈ�� �������� �����ϰ� �������� �������� �ʱ�ȭ
            instance.transform.localScale = Vector3.one;  // ���� �������� �����Ϸ� ����
        }
    }
}
