using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectScore : MonoBehaviour
{
    public Text scoreText;

    private int score = 0;

    void Start()
    {
        updateText();
    }

    public void upScore(int _score)
    {
        score += _score;
        updateText();
    }

    public int getScore()
    {
        return score;
    }

    void updateText()
    {
        scoreText.text = "Score\n" + score;
    }
}
