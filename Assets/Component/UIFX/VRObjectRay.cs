using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRObjectRay : MonoBehaviour
{
    public static VRObjectRay instance;
    // VR 오른쪽 컨트롤러
    public Transform rightHand;
    public OVRInput.Button button;

    //public GameObject Target;
    public string TagName;

    private GameObject prev = null;
    private bool condition = false;
    private void Awake()
    {
        instance = this;
    }

    public void setCondition(bool _condition)
    {
        condition = _condition;
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
                if(prev != null && prev != hit.collider.transform.Find("OnRay").gameObject)
                {
                    prev.SetActive(false);
                }
                prev = hit.collider.transform.Find("OnRay").gameObject;
                prev.SetActive(true);
            }
            else if (prev != null)
            {
                prev.gameObject.SetActive(false);
                prev = null;
            }

            if (prev != null && prev.gameObject.activeSelf && (OVRInput.GetDown(button) || condition))
            {
                Button btn = prev.transform.GetComponent<Button>();
                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
                condition = false;
            }
            
        }
    }
}