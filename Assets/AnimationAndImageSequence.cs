using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationAndImageSequence : MonoBehaviour
{
    public Animator animator;          // 애니메이터 컴포넌트
    public string animationName;       // 애니메이션 클립 이름
    public float animationDuration;    // 애니메이션 재생 시간 (초)
    public Image[] imagesToShow;       // 표시할 이미지들
    public float displayDuration = 1f; // 각 이미지를 표시할 시간 (초)

    private bool isAnimationStarted = false;

    private void Start()
    {
        // 애니메이션 시작
        animator.Play(animationName);
        isAnimationStarted = true;
    }

    private void Update()
    {
        if (isAnimationStarted)
        {
            isAnimationStarted = false;
            // 애니메이션 재생 시간 후 이미지 시퀀스 시작
            StartCoroutine(WaitAndDisplayImages(animationDuration));
        }
    }

    private IEnumerator WaitAndDisplayImages(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 애니메이션 재생 시간 대기
        foreach (var image in imagesToShow)
        {
            image.gameObject.SetActive(true); // 이미지 활성화
            yield return new WaitForSeconds(displayDuration); // 설정한 시간만큼 대기
            image.gameObject.SetActive(false); // 이미지 비활성화
        }
    }
}
