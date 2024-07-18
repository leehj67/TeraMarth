using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class VRObjectRay : MonoBehaviour
{
    // 1. 우선 해당 스크립트를 싱글톤으로 만들었다.
    public static VRObjectRay instance;


    // 2. 마우스 역할을 수행할 게임오브젝트를 준비한다.
    // VR 오른쪽 컨트롤러
    public Transform rightHand;
    // 마우스 포인터를 대체할 이미지
    public GameObject Target;
    public string TagName;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // 3. Ray를 사용해서 dot(마우스포인터)를 활성화한다.
        Ray ray = new Ray(rightHand.position, rightHand.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag(TagName))
            {
                Target.gameObject.SetActive(true);
            }
            else
            {
                Target.gameObject.SetActive(false);
            }

            if (Target.gameObject.activeSelf && OVRInput.GetDown(OVRInput.Button.Two))
            {
                // 버튼 스크립트를 가져온다
                Button btn = Target.transform.GetComponent<Button>();
                // 만약 btn이 null이 아니라면
                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
            }
            
        }
    }
}