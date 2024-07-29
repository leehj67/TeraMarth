using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSetUp : MonoBehaviour
{
    public XRInteractionManager xrInteractionManager;
    public XRBaseController controller;

    void Start()
    {
        // 원하는 위치와 회전으로 설정
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 180, 0); // 예시: 사용자를 180도 회전시킴
    }
}
