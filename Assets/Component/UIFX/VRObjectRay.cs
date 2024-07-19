using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class VRObjectRay : MonoBehaviour
{
    public static VRObjectRay instance;
    public OVRInput.Button button;

    // 2. ���콺 ������ ������ ���ӿ�����Ʈ�� �غ��Ѵ�.
    // VR ������ ��Ʈ�ѷ�
    public Transform rightHand;
    // ���콺 �����͸� ��ü�� �̹���
    public GameObject Target;
    public string TagName;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // 3. Ray�� ����ؼ� dot(���콺������)�� Ȱ��ȭ�Ѵ�.
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

            if (Target.gameObject.activeSelf && OVRInput.GetDown(button))
            {
                // ��ư ��ũ��Ʈ�� �����´�
                Button btn = Target.transform.GetComponent<Button>();
                // ���� btn�� null�� �ƴ϶��
                if (btn != null)
                {
                    btn.onClick.Invoke();
                }
            }
            
        }
    }
}