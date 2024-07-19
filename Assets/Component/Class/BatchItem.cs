using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatchItem : MonoBehaviour
{
    public HarvestItem harv;
    public SelectedItem selItem;
    public Text curTime;

    // itemCode는 SelectedItem.cs 참고
    public int itemCode = -1;
    
    private float timer = 0.0f;
    private float curtimer = 0.0f;
    private int min, sec;
    private bool updateTimer = false;

    void OnDisable()
    {
        if (itemCode != -1)
        {
            updateTimer = true;
        }
    }

    public void batch()
    {
        if (selItem.getItem() == -1)
        {
            if(timer > 0 && curtimer < 0)
            {
                harv.incScore(itemCode);
                curtimer = timer;
            }
            return;
        }
        itemCode = selItem.getItem();
        
        // 스킨 입히기
        gameObject.GetComponent<Renderer>().material = selItem.getMat(itemCode);

        selItem.setItem(-1);
        gameObject.SetActive(true);
        curTime.gameObject.SetActive(true);
        harv.incSet(itemCode);
        timer = SelectedItem.getItemTimer(itemCode);
        curtimer = timer;
    }

    void Update()
    {
        if (updateTimer)
        {
            curtimer -= selItem.getDelay();
            updateTimer = false;
        }
        if(curtimer < 0)
        {
            curTime.text = string.Format("수확");
            return;
        }
        min = (int)(curtimer / 60.0f);
        sec = (int)curtimer % 60;
        curTime.text = string.Format("{0:D2}:{1:D2}", min, sec);
        curtimer -= Time.deltaTime;
    }
}
