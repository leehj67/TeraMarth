using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // ������ ������ �迭
    public int numberOfObjects = 10; // ������ ������Ʈ�� ��
    public Vector3 spawnArea; // ���� ����

    private GameObject[] clones = null;

    public void clean()
    {
        if (clones == null) return;

        for (int i = 0; i < numberOfObjects; i++)
        {
            Destroy(clones[i]);
        }
        clones = null;
    }

    public void createPrefabs(int index)
    {
        if (clones != null) return;

        clones = new GameObject[numberOfObjects];

        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            ) + transform.position;

            GameObject selectedPrefab = prefabs[index];
            clones[i] = Instantiate(selectedPrefab, randomPosition, Quaternion.identity, transform);

            // �θ� ������Ʈ�� �������� �����ϰ� �������� �������� �ʱ�ȭ
            clones[i].transform.localScale = Vector3.one;  // ���� �������� �����Ϸ� ����
            clones[i].transform.parent = this.transform;
        }

    }
}
