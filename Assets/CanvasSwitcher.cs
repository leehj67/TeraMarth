using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas nextCanvas; // 활성화할 캔버스
    public OVRInput.Button controllerButton; // 컨트롤러에서 상호작용할 버튼

    private Button canvasButton;
    private Canvas curCanvas;

    void Start()
    {
        canvasButton = GetComponent<Button>();
        curCanvas = transform.parent.GetComponent<Canvas>();
        // 버튼의 onClick 이벤트에 메소드 연결
        if (canvasButton != null)
        {
            canvasButton.onClick.AddListener(ToggleCanvases);
        }
    }

    // 캔버스 전환 함수
    void ToggleCanvases()
    {
        if(curCanvas != null)
        {
            curCanvas.gameObject.SetActive(false);
        }
        nextCanvas.gameObject.SetActive(true);  // Canvas B 활성화
    }

    void Update()
    {
        if (controllerButton == OVRInput.Button.None) return;
        if (OVRInput.GetDown(controllerButton) && canvasButton != null)
        {
            canvasButton.onClick.Invoke();
        }
    }
}
