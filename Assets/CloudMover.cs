using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 50.0f; // 이미지의 움직임 속도
    private RectTransform rectTransform; // 이미지의 RectTransform 컴포넌트
    private float initialX; // 초기 x 위치
    private float canvasWidth; // Canvas의 너비

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // RectTransform 컴포넌트 가져오기
        initialX = rectTransform.anchoredPosition.x; // 초기 x 위치 저장
        canvasWidth = GetComponentInParent<Canvas>().GetComponent<RectTransform>().rect.width; // Canvas의 너비를 구함
    }

    void Update()
    {
        // 오른쪽에서 왼쪽으로 이미지 이동
        rectTransform.anchoredPosition -= new Vector2(speed * Time.deltaTime, 0);

        // 이미지가 왼쪽으로 완전히 나가면 다시 오른쪽에서 시작
        if (rectTransform.anchoredPosition.x < -rectTransform.rect.width)
        {
            rectTransform.anchoredPosition = new Vector2(initialX + canvasWidth, rectTransform.anchoredPosition.y);
        }
    }
}
