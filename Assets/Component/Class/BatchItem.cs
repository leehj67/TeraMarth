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
    public GameObject mappingSpawner;

    // itemCode�� SelectedItem.cs ����
    private int itemCode = -1;
    public Category staticCategory;
    public bool isSuperBlock = false;
    public float timeX = 2.0f;
    public int scoreX = 4;
    
    private float timer = -1.0f;
    private float curtimer = 0.0f;
    private int min, sec;
    private bool updateTimer = false;
    private int score;
    private float time;

    void OnDisable()
    {
        if (itemCode != -1)
        {
            updateTimer = true;
        }
    }

    void spawnObjects()
    {
        if (staticCategory == Category.vegitable)
        {
            mappingSpawner.GetComponent<PrefabSpawner>().createPrefabs(itemCode);
        }
        else if (staticCategory == Category.animal)
        {
            mappingSpawner.GetComponent<RandomPrefabSpawner>().createPrefabs(itemCode);
        }
    }

    void clearObejcts()
    {
        if (staticCategory == Category.vegitable)
        {
            mappingSpawner.GetComponent<PrefabSpawner>().clean();
        }
        else if (staticCategory == Category.animal)
        {
            mappingSpawner.GetComponent<RandomPrefabSpawner>().clean();
        }
    }

    public void batch()
    {
        if (selItem.getItem() == -1)
        {
            if(timer < 0 || curtimer > 0) return;
            
            if (isSuperBlock) score = scoreX;
            else score = 1;

            harv.incScore(itemCode, score);
            timer = -1.0f;
            curtimer = timer;
            clearObejcts();

            itemCode = -1;
            gameObject.SetActive(false);
            curTime.gameObject.SetActive(false);

            return;
        }

        if (itemCode != -1 || selItem.getCategory() != staticCategory)
        {
            selItem.setItem(-1, Category.None);
            return;
        }

        itemCode = selItem.getItem();
        
        // ��Ų ������
        gameObject.GetComponent<Renderer>().material = selItem.getMat(itemCode);
        spawnObjects();

        // ����ִ� �� ����
        selItem.setItem(-1, Category.None);
        gameObject.SetActive(true);
        curTime.gameObject.SetActive(true);
        harv.incSet(itemCode);

        if (isSuperBlock) time = timeX;
        else time = 1.0f;

        timer = SelectedItem.getItemTimer(itemCode) * time;
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
            curTime.text = string.Format("��Ȯ");
            return;
        }
        min = (int)(curtimer / 60.0f);
        sec = (int)curtimer % 60;
        curTime.text = string.Format("{0:D2}:{1:D2}", min, sec);
        curtimer -= Time.deltaTime;
    }
}
