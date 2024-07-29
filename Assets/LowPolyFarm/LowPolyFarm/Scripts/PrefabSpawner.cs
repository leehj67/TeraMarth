using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // 생성할 프리팹들의 배열
    public int numberOfRows = 3; // 생성할 오브젝트의 행 수
    public int numberOfColumns = 5; // 생성할 오브젝트의 열 수
    public float spacing = 2.0f; // 오브젝트 사이의 간격

    void Start()
    {
        Vector3 startPosition = transform.position; // 부모 오브젝트의 위치를 시작 위치로 사용
        ShufflePrefabs(); // 프리팹 배열을 무작위로 섞음

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                // 무작위로 선택된 프리팹을 생성하고 위치를 설정
                GameObject selectedPrefab = prefabs[Random.Range(0, prefabs.Length)];
                GameObject obj = Instantiate(selectedPrefab, new Vector3(startPosition.x + col * spacing, startPosition.y, startPosition.z + row * spacing), Quaternion.identity, transform);

                // 생성된 프리팹을 현재 스크립트가 있는 오브젝트의 자식으로 설정
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
