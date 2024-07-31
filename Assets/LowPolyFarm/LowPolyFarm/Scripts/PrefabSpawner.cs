using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // 생성할 프리팹들의 배열
    public int numberOfRows = 3; // 생성할 오브젝트의 행 수
    public int numberOfColumns = 5; // 생성할 오브젝트의 열 수
    public float spacing = 2.0f; // 오브젝트 사이의 간격

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

        Vector3 startPosition = transform.position; // 부모 오브젝트의 위치를 시작 위치로 사용
        clones = new GameObject[numberOfRows,numberOfColumns];

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                GameObject selectedPrefab = prefabs[index];
                clones[row, col] = Instantiate(selectedPrefab, new Vector3(startPosition.x + col * spacing, startPosition.y, startPosition.z + row * spacing), Quaternion.identity, transform);

                // 생성된 프리팹을 현재 스크립트가 있는 오브젝트의 자식으로 설정
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
