using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageBatchDisplayWithIntervalController : MonoBehaviour
{
    public Image[] images;         // 보여줄 이미지 배열
    public int imagesPerBatch = 3; // 한 번에 보여줄 이미지 개수
    public float displayInterval = 1.0f; // 각 이미지를 보여주는 시간 (초)
    public float imageInterval = 0.5f;   // 이미지 간의 간격 시간 (초)
    public float batchInterval = 1.0f;   // 묶음 간의 간격 시간 (초)

    void Start()
    {
        StartCoroutine(DisplayImagesInBatches());
    }

    IEnumerator DisplayImagesInBatches()
    {
        int totalImages = images.Length;
        int totalBatches = Mathf.CeilToInt((float)totalImages / imagesPerBatch);

        for (int batch = 0; batch < totalBatches; batch++)
        {
            // 현재 묶음에 속하는 이미지들을 순차적으로 활성화
            for (int i = 0; i < imagesPerBatch; i++)
            {
                int index = batch * imagesPerBatch + i;
                if (index < totalImages)
                {
                    images[index].gameObject.SetActive(true);
                    yield return new WaitForSeconds(imageInterval); // 이미지 간의 간격 시간 대기
                }
            }

            // 각 묶음의 마지막 이미지를 일정 시간 동안 표시
            yield return new WaitForSeconds(displayInterval);

            // 현재 묶음의 모든 이미지 비활성화
            for (int i = 0; i < imagesPerBatch; i++)
            {
                int index = batch * imagesPerBatch + i;
                if (index < totalImages)
                {
                    images[index].gameObject.SetActive(false);
                }
            }

            // 묶음 간의 간격 시간 대기
            if (batch < totalBatches - 1) // 마지막 묶음이 아닌 경우에만 대기
            {
                yield return new WaitForSeconds(batchInterval);
            }
        }
    }
}
