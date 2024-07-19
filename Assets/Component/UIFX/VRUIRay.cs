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
                    // ��ư ��ũ��Ʈ�� �����´�
                    Button btn = hit.transform.GetComponent<Button>();
                    // ���� btn�� null�� �ƴ϶��
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