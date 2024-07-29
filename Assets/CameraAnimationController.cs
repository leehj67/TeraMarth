using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public Transform cameraTransform; // 실제 XR 카메라의 Transform
    public AnimationClip cameraAnimation; // 적용할 카메라 애니메이션

    void Start()
    {
        // 초기 카메라 위치와 회전을 저장
        initialPosition = cameraTransform.position;
        initialRotation = cameraTransform.rotation;

        // 애니메이션 시작
        ApplyAnimation();
    }

    void ApplyAnimation()
    {
        // 애니메이션 클립을 Transform에 적용하거나 애니메이션 시스템을 통해 조정
        // 예를 들어, Animation 컴포넌트나 Animator를 사용하여 애니메이션을 조정합니다.
        Animation anim = cameraTransform.gameObject.AddComponent<Animation>();
        anim.AddClip(cameraAnimation, "CameraMove");
        anim.Play("CameraMove");
    }

    void Update()
    {
        // 카메라의 실시간 위치와 회전을 재조정
        cameraTransform.position = initialPosition;
        cameraTransform.rotation = initialRotation;
    }
}
