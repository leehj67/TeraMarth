using UnityEngine;
using UnityEngine.UI;

public class HarvestItem : MonoBehaviour
{
    public Text logScore;
    public int[] nofSet;
    public int[] score;

    public void incSet(int index)
    {
        if (0 <= index && index < nofSet.Length)
        {
            nofSet[index] += 1;
        }
    }

    public void incScore(int index, int point = 1)
    {
        if(0 <= index && index < score.Length)
        {
            score[index] += point;
        }
    }

    void Update()
    {
        string s = "Item\n";
        for(int i = 0; i < nofSet.Length; ++i)
        {
            s += string.Format("{0:D}:{1:D} ", i, nofSet[i]);
        }
        s += "\n";
        for (int i = 0; i < score.Length; ++i)
        {
            s += string.Format("{0:D}:{1:D} ", i, score[i]);
        }
        logScore.text = s;
    }
}
