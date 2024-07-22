using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public static CanvasSwitcher instance;

    public Canvas canvasA; // 비활성화할 캔버스
    public Canvas canvasB; // 활성화할 캔버스
    public Button switchButton; // 캔버스를 전환할 버튼
    public OVRInput.Button controllerButton; // 컨트롤러에서 상호작용할 버튼

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // 버튼의 onClick 이벤트에 메소드 연결
        switchButton.onClick.AddListener(ToggleCanvases);
    }

    // 캔버스 전환 함수
    void ToggleCanvases()
    {
        canvasA.gameObject.SetActive(false); // Canvas A 비활성화
        canvasB.gameObject.SetActive(true);  // Canvas B 활성화
    }

    void Update()
    {
        if (controllerButton == 0) return;
        if (OVRInput.GetDown(controllerButton) && switchButton != null)
        {
            switchButton.onClick.Invoke();
        }
    }
}
