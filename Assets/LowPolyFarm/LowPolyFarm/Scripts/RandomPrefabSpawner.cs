using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // 생성할 프리팹 배열
    public int numberOfObjects = 10; // 생성할 오브젝트의 수
    public Vector3 spawnArea; // 생성 영역

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

            // 부모 오브젝트의 스케일을 무시하고 프리팹의 스케일을 초기화
            clones[i].transform.localScale = Vector3.one;  // 원래 프리팹의 스케일로 설정
            clones[i].transform.parent = this.transform;
        }

    }
}
