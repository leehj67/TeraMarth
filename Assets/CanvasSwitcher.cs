using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas canvasA; // 비활성화할 캔버스
    public Canvas canvasB; // 활성화할 캔버스
    public Button switchButton; // 캔버스를 전환할 버튼

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
}
