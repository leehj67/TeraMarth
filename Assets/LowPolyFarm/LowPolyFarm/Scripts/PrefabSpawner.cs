using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // ������ �����յ��� �迭
    public int numberOfRows = 3; // ������ ������Ʈ�� �� ��
    public int numberOfColumns = 5; // ������ ������Ʈ�� �� ��
    public float spacing = 2.0f; // ������Ʈ ������ ����

    private GameObject[,] clones = null;

    public void clean()
    {
        if (clones == null) return;

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                Destroy(clones[row, col]);
            }
        }
        clones = null;
    }

    public void createPrefabs(int index)
    {
        if (clones != null) return;

        Vector3 startPosition = transform.position; // �θ� ������Ʈ�� ��ġ�� ���� ��ġ�� ���
        clones = new GameObject[numberOfRows,numberOfColumns];

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                GameObject selectedPrefab = prefabs[index];
                clones[row, col] = Instantiate(selectedPrefab, new Vector3(startPosition.x + col * spacing, startPosition.y, startPosition.z + row * spacing), Quaternion.identity, transform);

                // ������ �������� ���� ��ũ��Ʈ�� �ִ� ������Ʈ�� �ڽ����� ����
                clones[row, col].transform.parent = this.transform;
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
