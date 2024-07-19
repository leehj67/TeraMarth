using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRUIRay : MonoBehaviour
{
    public static VRUIRay instance;

    public Transform rightHand;
    public Transform dot;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        Ray ray = new Ray(rightHand.position, rightHand.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                dot.gameObject.SetActive(true);
                dot.position = hit.point;
            }
            else
            {
                dot.gameObject.SetActive(false);
            }

            /*
            if (dot.gameObject.activeSelf)
            {
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    // 버튼 스크립트를 가져온다
                    Button btn = hit.transform.GetComponent<Button>();
                    // 만약 btn이 null이 아니라면
                    if (btn != null)
                    {
                        btn.onClick.Invoke();
                    }
                }
            }
            */
        }
        else
        {
            dot.gameObject.SetActive(false);
        }
    }
}