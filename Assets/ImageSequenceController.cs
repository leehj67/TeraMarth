using System.Collections;
using UnityEngine;

public class ImageSequenceController : MonoBehaviour
{
    public GameObject[] firstSetOfImages; // 첫 번째 이미지 세트
    public GameObject[] secondSetOfImages; // 두 번째 이미지 세트
    public float activationInterval = 2.0f; // 이미지 활성화 간격 (초)
    public float pauseBetweenSets = 3.0f; // 세트 간 일시 중지 시간 (초)

    void Start()
    {
        StartCoroutine(ManageImageSequences());
    }

    IEnumerator ManageImageSequences()
    {
        // 첫 번째 이미지 세트 활성화
        yield return StartCoroutine(ActivateImagesSequentially(firstSetOfImages, activationInterval));
        yield return new WaitForSeconds(pauseBetweenSets);

        // 첫 번째 이미지 세트 비활성화
        foreach (var image in firstSetOfImages)
        {
            image.SetActive(false);
        }

        // 두 번째 이미지 세트 활성화
        yield return StartCoroutine(ActivateImagesSequentially(secondSetOfImages, activationInterval));
    }

    IEnumerator ActivateImagesSequentially(GameObject[] images, float interval)
    {
        foreach (var image in images)
        {
            image.SetActive(true);
            yield return new WaitForSeconds(interval);
        }
    }
}
