using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    // -1: 아무것도 없음
    private int itemCode = -1;
    private Category category = Category.None;

    public GameObject screen;
    public Material[] materials;
    private float delay = 0.0f;
    private bool prev = false;

    public void setItem(int _itemCode, Category _category)
    {
        itemCode = _itemCode;
        category = _category;
    }

    public Material getMat(int index)
    {
        if(0 <= index && index < materials.Length && materials[index] != null)
        {
            return materials[index];
        }

        return materials[0];
    }

    public int getItem()
    {
        return itemCode;
    }

    public Category getCategory()
    {
        return category;
    }

    public static float getItemTimer(int index)
    {
        if (index < 0) return -1f;

        if (index == 0) return 10.0f;   // 옥수수:   10초 재배
        if (index == 1) return 12.0f;   // 호박:     12초 재배
        if (index == 2) return 8.0f;    // 토마토:   8초 재배
        if (index == 3) return 16.0f;   // 당근:     16초 재배
        if (index == 4) return 20.0f;   // 양배추:   20초 재배
        if (index == 5) return 24.0f;   // 샐러드:   24초 재배
        if (index == 6) return 40.0f;   // 해바라기: 40초 재배
        if (index == 7) return 50.0f;   // 소:       50초 재배
        if (index == 8) return 40.0f;   // 닭:       40초 재배
        if (index == 9) return 60.0f;   // 양:       60초 재배
        if (index == 10) return 120.0f; // 말:       120초 재배
        if (index == 11) return 75.0f;  // 염소:     75초 재배

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
