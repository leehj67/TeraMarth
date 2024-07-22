using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class VRButtonRayInteract : MonoBehaviour
{
    public XRBaseControllerInteractor rayInteractor; // 레이 인터랙터 컴포넌트
    public Button uiButton; // 클릭할 UI 버튼
    public GameObject imageToToggle; // 토글할 이미지

    private void OnEnable()
    {
        rayInteractor.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDisable()
    {
        rayInteractor.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // 선택된 객체가 UI 버튼인지 확인
        if (args.interactable.transform == uiButton.transform)
        {
            // 버튼 클릭 실행 및 이미지 활성화
            uiButton.onClick.Invoke();
            ToggleImage();
        }
    }

    // 이미지 활성화/비활성화 토글 함수
    void ToggleImage()
    {
        // 이미지 게임 오브젝트의 활성화 상태 토글
        imageToToggle.SetActive(!imageToToggle.activeSelf);
    }
}
