using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLooper : MonoBehaviour
{
    public Animator animator;
    public string runAnimationStateName = "HumanoidRun";
    public string focusAnimationStateName = "Focus";
    public int runRepeatCount = 15; // HumanoidRun �ִϸ��̼� �ݺ� Ƚ��
    public int focusRepeatCount = 2; // Focus �ִϸ��̼� �ݺ� Ƚ��
    private int currentRunCount = 0;
    private int currentFocusCount = 0;
    private bool isRunning = true;
    private bool isPlayingRun = true; // ���� HumanoidRun �ִϸ��̼� ��� ����

    void Start()
    {
        // �ʱ�ȭ
        animator.SetBool("isRunComplete", false);
        animator.SetBool("isFocusComplete", false);
        PlayRunAnimation();
    }

    void PlayRunAnimation()
    {
        animator.Play(runAnimationStateName, -1, 0f); // HumanoidRun �ִϸ��̼� �ʱ�ȭ �� ���
    }

    void PlayFocusAnimation()
    {
        animator.Play(focusAnimationStateName, -1, 0f); // Focus �ִϸ��̼� �ʱ�ȭ �� ���
    }

    void Update()
    {
        if (isRunning)
        {
            // ���� �ִϸ��̼� ���� ���� ��������
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (isPlayingRun)
            {
                // HumanoidRun �ִϸ��̼��� �������� Ȯ��
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
                        currentRunCount = 0; // �ʱ�ȭ
                        PlayFocusAnimation();
                    }
                }
            }
            else
            {
                // Focus �ִϸ��̼��� �������� Ȯ��
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
                        animator.SetBool("isFocusComplete", true); // Transition ���� ����
                    }
                }
            }
        }
    }
}
