using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public int stage = 1;
    public int maxState = 4;
    public GameObject line;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = (float)stage/maxState;
        RectTransform rectTransform = GetComponent<RectTransform>();
        for(int i = 0; i < maxState - 1; ++i)
        {
            RectTransform clone = Instantiate(line, rectTransform).GetComponent<RectTransform>();
            clone.anchoredPosition3D =
                new Vector3((float)rectTransform.sizeDelta.x / maxState * (i + 1),
                clone.anchoredPosition3D.y, clone.anchoredPosition3D.z);
        }
        
    }

    void stageUpdate()
    {
        GetComponent<Slider>().value = (float)stage / maxState;
    }
}
