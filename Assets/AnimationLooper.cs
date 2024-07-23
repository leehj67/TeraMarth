using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLooper : MonoBehaviour
{
    public Animator animator;
    public string runAnimationStateName = "HumanoidRun";
    public string focusAnimationStateName = "Focus";
    public int repeatCount = 6; // HumanoidRun �ִϸ��̼� �ݺ� Ƚ��
    private int currentCount = 0;
    private bool isRunning = true;

    void Start()
    {
        // HumanoidRun �ִϸ��̼� ��� ����
        animator.SetBool("isRunComplete", false); // �ʱ�ȭ
        PlayRunAnimation();
    }

    void PlayRunAnimation()
    {
        animator.Play(runAnimationStateName, -1, 0f); // �ִϸ��̼� �ʱ�ȭ �� ���
    }

    void Update()
    {
        if (isRunning)
        {
            // ���� �ִϸ��̼� ���� ���� ��������
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // HumanoidRun �ִϸ��̼��� �������� Ȯ��
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
                    animator.SetBool("isRunComplete", true); // Transition ���� ����
                }
            }
        }
    }
}
