using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageSequencer : MonoBehaviour
{
    public GameObject[] images; // 활성화할 이미지 배열
    public Button continueButton; // 활성화할 버튼
    public float delay = 2.0f; // 이미지 간 지연 시간 (초)

    private void Start()
    {
        continueButton.gameObject.SetActive(false); // 버튼을 초기에 비활성화
        StartCoroutine(ActivateImagesInSequence());
    }

    IEnumerator ActivateImagesInSequence()
    {
        foreach (GameObject image in images)
        {
            image.SetActive(true); // 이미지 활성화
            yield return new WaitForSeconds(delay); // 다음 이미지 활성화 전 지연
        }
        continueButton.gameObject.SetActive(true); // 모든 이미지가 활성화된 후 버튼 활성화
    }
}
