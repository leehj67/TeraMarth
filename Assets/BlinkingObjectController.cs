using System.Collections;
using UnityEngine;

public class BlinkingObjectController : MonoBehaviour
{
    public GameObject objectToBlink; // 점등할 오브젝트
    public GameObject objectToShow;  // 점등 후 보여줄 오브젝트
    public int blinkCount = 3;       // 점등할 횟수
    public float blinkInterval = 0.5f; // 점등 간격 (초)

    private void Start()
    {
        // 처음에 objectToShow는 비활성화 상태로 설정
        objectToShow.SetActive(false);
        
        // 점등을 시작
        StartCoroutine(BlinkAndShowObject());
    }

    private IEnumerator BlinkAndShowObject()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            // 오브젝트 활성화
            objectToBlink.SetActive(true);
            yield return new WaitForSeconds(blinkInterval);
            
            // 오브젝트 비활성화
            objectToBlink.SetActive(false);
            yield return new WaitForSeconds(blinkInterval);
        }

        // 점등이 완료된 후, 다른 오브젝트를 활성화
        objectToShow.SetActive(true);
    }
}
