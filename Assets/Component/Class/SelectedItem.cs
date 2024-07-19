using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    // -1: �ƹ��͵� ����
    // 0: �׽�Ʈ �뵵(3��)
    // [1:����, 2:��, 3:����, 4:����, 5:��, 6:��, 7:�����, 8:����]
    private int itemCode = -1;

    public GameObject screen;
    public Material[] materials;
    private float delay = 0.0f;
    private bool prev = false;

    public void setItem(int index)
    {
        itemCode = index;
    }

    public Material getMat(int index)
    {
        if(0 < index && index < materials.Length && materials[index] != null)
        {
            return materials[index];
        }

        return materials[0];
    }

    public int getItem()
    {
        return itemCode;
    }

    public static float getItemTimer(int index)
    {
        if (index < 0) return -1f;

        if (index == 0) return 3.0f;    // �׽�Ʈ:3�� ���
        if (index == 1) return 20.0f;   // ����:  20�� ���
        if (index == 2) return 8.0f;    // ��:    8�� ���
        if (index == 3) return 120.0f;  // ����:  120�� ���
        if (index == 4) return 30.0f;   // ����:  30�� ���
        if (index == 5) return 40.0f;   // ��:    40�� ���
        if (index == 6) return 10.0f;   // ��:    10�� ���
        if (index == 7) return 45.0f;   // �����:45�� ���
        if (index == 8) return 25.0f;   // ����:  25�� ���

        return -1f;
    }

    public float getDelay()
    {
        return delay;
    }

    void Update()
    {
        if (!screen.activeSelf && prev)
        {
            delay = Time.deltaTime;
            prev = false;
        }
        else if (!screen.activeSelf)
        {
            delay += Time.deltaTime;
            prev = false;
        }
        else if (screen.activeSelf)
        {
            prev = true;
        }
    }
}
