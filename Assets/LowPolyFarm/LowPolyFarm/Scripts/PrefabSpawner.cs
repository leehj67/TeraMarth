using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // ������ �����յ��� �迭
    public int numberOfRows = 3; // ������ ������Ʈ�� �� ��
    public int numberOfColumns = 5; // ������ ������Ʈ�� �� ��
    public float spacing = 2.0f; // ������Ʈ ������ ����

    void Start()
    {
        Vector3 startPosition = transform.position; // �θ� ������Ʈ�� ��ġ�� ���� ��ġ�� ���
        ShufflePrefabs(); // ������ �迭�� �������� ����

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                // �������� ���õ� �������� �����ϰ� ��ġ�� ����
                GameObject selectedPrefab = prefabs[Random.Range(0, prefabs.Length)];
                GameObject obj = Instantiate(selectedPrefab, new Vector3(startPosition.x + col * spacing, startPosition.y, startPosition.z + row * spacing), Quaternion.identity, transform);

                // ������ �������� ���� ��ũ��Ʈ�� �ִ� ������Ʈ�� �ڽ����� ����
                obj.transform.parent = this.transform;
            }
        }
    }

    void ShufflePrefabs()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject temp = prefabs[i];
            int randomIndex = Random.Range(i, prefabs.Length);
            prefabs[i] = prefabs[randomIndex];
            prefabs[randomIndex] = temp;
        }
    }
}
