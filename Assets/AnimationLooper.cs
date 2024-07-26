using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLooper : MonoBehaviour
{
    public Animator animator;
    public string runAnimationStateName = "HumanoidRun";
    public string focusAnimationStateName = "Focus";
    public int runRepeatCount = 15; // HumanoidRun 애니메이션 반복 횟수
    public int focusRepeatCount = 2; // Focus 애니메이션 반복 횟수
    private int currentRunCount = 0;
    private int currentFocusCount = 0;
    private bool isRunning = true;
    private bool isPlayingRun = true; // 현재 HumanoidRun 애니메이션 재생 여부

    void Start()
    {
        // 초기화
        animator.SetBool("isRunComplete", false);
        animator.SetBool("isFocusComplete", false);
        PlayRunAnimation();
    }

    void PlayRunAnimation()
    {
        animator.Play(runAnimationStateName, -1, 0f); // HumanoidRun 애니메이션 초기화 후 재생
    }

    void PlayFocusAnimation()
    {
        animator.Play(focusAnimationStateName, -1, 0f); // Focus 애니메이션 초기화 후 재생
    }

    void Update()
    {
        if (isRunning)
        {
            // 현재 애니메이션 상태 정보 가져오기
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (isPlayingRun)
            {
                // HumanoidRun 애니메이션이 끝났는지 확인
                if (stateInfo.IsName(runAnimationStateName) && stateInfo.normalizedTime >= 1.0f && !animator.IsInTransition(0))
                {
                    currentRunCount++;

                    if (currentRunCount < runRepeatCount)
                    {
                        PlayRunAnimation();
                    }
                    else
                    {
                        isPlayingRun = false;
                        currentRunCount = 0; // 초기화
                        PlayFocusAnimation();
                    }
                }
            }
            else
            {
                // Focus 애니메이션이 끝났는지 확인
                if (stateInfo.IsName(focusAnimationStateName) && stateInfo.normalizedTime >= 1.0f && !animator.IsInTransition(0))
                {
                    currentFocusCount++;

                    if (currentFocusCount < focusRepeatCount)
                    {
                        PlayFocusAnimation();
                    }
                    else
                    {
                        isRunning = false;
                        animator.SetBool("isFocusComplete", true); // Transition 조건 설정
                    }
                }
            }
        }
    }
}
