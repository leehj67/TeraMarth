using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // 이동할 씬의 이름
    public OVRInput.Button controllerButton; // 컨트롤러에서 상호작용할 버튼

    private Button canvasButton;

    void Start()
    {
        canvasButton = GetComponent<Button>();
        // 버튼의 onClick 이벤트에 메소드 연결
        if (canvasButton != null)
        {
            canvasButton.onClick.AddListener(ChangeScene);
        }
    }

    // 씬 전환 함수
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
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
