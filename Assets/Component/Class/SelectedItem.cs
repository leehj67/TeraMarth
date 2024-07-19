using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    // -1: 아무것도 없음
    // 0: 테스트 용도(3초)
    // [1:감자, 2:꽃, 3:나무, 4:돼지, 5:소, 6:닭, 7:물고기, 8:새우]
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

        if (index == 0) return 3.0f;    // 테스트:3초 재배
        if (index == 1) return 20.0f;   // 감자:  20초 재배
        if (index == 2) return 8.0f;    // 꽃:    8초 재배
        if (index == 3) return 120.0f;  // 나무:  120초 재배
        if (index == 4) return 30.0f;   // 돼지:  30초 재배
        if (index == 5) return 40.0f;   // 소:    40초 재배
        if (index == 6) return 10.0f;   // 닭:    10초 재배
        if (index == 7) return 45.0f;   // 물고기:45초 재배
        if (index == 8) return 25.0f;   // 새우:  25초 재배

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
