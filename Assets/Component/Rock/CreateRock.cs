using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CreateRock : MonoBehaviour
{
    public BoxCollider start;
    public BoxCollider end;
    public GameObject[] rocks;
    public CollectScore scoreE;

    public float cycle;
    public float speed;
    public float size;
    public int[] healths;

    private float curT = 0;
    private int type;

    void Start()
    {

        Vector3 randomPoint = GetRandomPointInBoxCollider(start);
    }

    Vector3 GetRandomPointInBoxCollider(BoxCollider boxCollider)
    {
        // BoxCollider의 중심과 크기
        Vector3 center = boxCollider.center;
        Vector3 size = boxCollider.size;

        // 로컬 공간에서의 랜덤 위치 계산
        Vector3 randomPosition = new Vector3(
            Random.Range(-size.x / 2, size.x / 2),
            Random.Range(-size.y / 2, size.y / 2),
            Random.Range(-size.z / 2, size.z / 2)
        );

        // 로컬 위치를 월드 위치로 변환
        return boxCollider.transform.TransformPoint(center + randomPosition);
    }

    void createRock()
    {
        Vector3 startPoint = GetRandomPointInBoxCollider(start);
        Vector3 endPoint = GetRandomPointInBoxCollider(end);
        Vector3 direction = (endPoint - startPoint).normalized;

        GameObject rock = Instantiate(rocks[Random.Range(0, rocks.Length)], startPoint, Quaternion.identity);
        rock.GetComponent<Rigidbody>().velocity = direction * speed;
        type = Random.Range(0, healths.Length);
        rock.GetComponent<RockLife>().setHP(healths[type], type);
        rock.GetComponent<RockLife>().setScoreE(scoreE);
        rock.transform.localScale = Vector3.one * (type + 1) * size;
    }

    void Update()
    {
        curT += Time.deltaTime;
        if (curT > cycle)
        {
            createRock();
            curT = 0;
        }
    }
}
