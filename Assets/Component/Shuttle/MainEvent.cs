using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainEvent : MonoBehaviour
{
    public float playTime;
    public GameObject prevUI;
    // 0번째에 스코어 오브젝트를 넣어주세요..
    public GameObject[] eventObjects;
    public Text remainTime;

    public GameObject nextUI;
    public Text scoreText;

    private bool eTrigger = false;
    private float curT;

    void updateRemainTime()
    {
        remainTime.text = "남은시간\n" + curT.ToString("F1");
    }

    public void eventStart()
    {
        curT = playTime;
        prevUI.SetActive(false);
        foreach(GameObject e in eventObjects)
        {
            e.SetActive(true);
        }
        eTrigger = true;
    }

    void endEvent()
    {
        scoreText.text = "최종 흭득 점수\n" + eventObjects[0].GetComponent<CollectScore>().getScore() + " 점";
        foreach (GameObject e in eventObjects)
        {
            e.SetActive(false);
        }
        nextUI.SetActive(true);
        eTrigger = false;
    }

    void Update()
    {
        if (eTrigger)
        {
            curT -= Time.deltaTime;
            if(curT < 0)
            {
                endEvent();
            }
            updateRemainTime();
        }
    }
}
