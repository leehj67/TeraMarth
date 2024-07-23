using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLooper : MonoBehaviour
{
    public Animator animator;
    public string runAnimationStateName = "HumanoidRun";
    public string focusAnimationStateName = "Focus";
    public int repeatCount = 6; // HumanoidRun 애니메이션 반복 횟수
    private int currentCount = 0;
    private bool isRunning = true;

    void Start()
    {
        // HumanoidRun 애니메이션 재생 시작
        animator.SetBool("isRunComplete", false); // 초기화
        PlayRunAnimation();
    }

    void PlayRunAnimation()
    {
        animator.Play(runAnimationStateName, -1, 0f); // 애니메이션 초기화 후 재생
    }

    void Update()
    {
        if (isRunning)
        {
            // 현재 애니메이션 상태 정보 가져오기
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // HumanoidRun 애니메이션이 끝났는지 확인
            if (stateInfo.IsName(runAnimationStateName) && stateInfo.normalizedTime >= 1.0f && !animator.IsInTransition(0))
            {
                currentCount++;

                if (currentCount < repeatCount)
                {
                    PlayRunAnimation();
                }
                else
                {
                    isRunning = false;
                    animator.SetBool("isRunComplete", true); // Transition 조건 설정
                }
            }
        }
    }
}
