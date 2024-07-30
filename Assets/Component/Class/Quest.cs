using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Text[] questText;
    public HarvestItem hav;
    public Progress prg;
    public GameObject nextButton;
    public bool cheat;
    public string[][] quest;
    public string nextScene;

    void Start()
    {
        quest = new string[prg.maxState + 1][];
        for (int i = 1; i <= quest.Length; i++)
        {
            if (i == 1) quest[i] = new string[] {
                "���ڸ� 1ȸ ��������.", "���ڸ� 5ȸ ��Ȯ�ϼ���.", "", ""
            };
            else if (i == 2) quest[i] = new string[] {
                "���� 3ȸ ��������.", "���� 10ȸ ��Ȯ�ϼ���.", "������ 2ȸ ��������.", "������ 2ȸ ��Ȯ�ϼ���."
            };
            else if (i == 3) quest[i] = new string[] {
                "������ 5ȸ �����ϼ���.", "�Ҹ� 3ȸ �����ϼ���.", "���� 10ȸ �����ϼ���.", ""
            };
            else if (i == 4) quest[i] = new string[] {
                "������ 10ȸ ��Ȯ�ϼ���.", "�Ҹ� 15ȸ �����ϼ���.", "����⸦ 20ȸ ��Ȯ�ϼ���.", "���츦 30ȸ ��Ȯ�ϼ���."
            };
        }
        resetLine();
        questUpdate(1);
    }

    private void questUpdate(int index)
    {
        for (int i = 0; i < questText.Length; ++i)
        {
            if (quest[index][i] != "")
            {
                questText[i].text = string.Format("{0:D}. ", i + 1) + quest[index][i];
            }
            else
            {
                questText[i].text = "";
            }
        }
    }

    private bool conditions(int index)
    {
        if(index == 1)
        {
            if (!questText[0].transform.Find("ClearLine").gameObject.activeSelf && hav.nofSet[1] >= 1)
            {
                questText[0].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[1].transform.Find("ClearLine").gameObject.activeSelf && hav.score[1] >= 5)
            {
                questText[1].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            return clearLineActive(2);
        }
        else if (index == 2)
        {
            if (!questText[0].transform.Find("ClearLine").gameObject.activeSelf && hav.nofSet[2] >= 3)
            {
                questText[0].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[1].transform.Find("ClearLine").gameObject.activeSelf && hav.score[2] >= 10)
            {
                questText[1].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[2].transform.Find("ClearLine").gameObject.activeSelf && hav.nofSet[3] >= 2)
            {
                questText[2].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[3].transform.Find("ClearLine").gameObject.activeSelf && hav.score[3] >= 2)
            {
                questText[3].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            return clearLineActive(4);
        }
        else if (index == 3)
        {
            if (!questText[0].transform.Find("ClearLine").gameObject.activeSelf && hav.score[4] >= 5)
            {
                questText[0].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[1].transform.Find("ClearLine").gameObject.activeSelf && hav.score[5] >= 3)
            {
                questText[1].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[2].transform.Find("ClearLine").gameObject.activeSelf && hav.score[6] >= 10)
            {
                questText[2].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            return clearLineActive(3);
        }
        else if (index == 4)
        {
            if (!questText[0].transform.Find("ClearLine").gameObject.activeSelf && hav.score[3] >= 10)
            {
                questText[0].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[1].transform.Find("ClearLine").gameObject.activeSelf && hav.score[5] >= 15)
            {
                questText[1].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[2].transform.Find("ClearLine").gameObject.activeSelf && hav.score[7] >= 20)
            {
                questText[2].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[3].transform.Find("ClearLine").gameObject.activeSelf && hav.score[8] >= 30)
            {
                questText[3].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            return clearLineActive(4);
        }

        return false;
    }

    private bool clearLineActive(int n)
    {
        for(int i = 0; i < n; ++i)
        {
            if (!questText[i].transform.Find("ClearLine").gameObject.activeSelf)
                return false;
        }
        return true;
    }

    public void nextProgress()
    {
        if (cheat)
        {
            SceneManager.LoadScene(nextScene);
            return;
        }

        if(prg.stage == prg.maxState)
        {
            // ���������� �̵�
            SceneManager.LoadScene(nextScene);
            return;
        }

        prg.stage++;
        prg.stageUpdate();
        questUpdate(prg.stage);
        resetLine();
    }

    private void resetLine()
    {
        for(int i = 0; i < questText.Length; ++i)
        {
            questText[i].transform.Find("ClearLine").gameObject.SetActive(false);
        }
        nextButton.SetActive(false);
    }

    void Update()
    {
        if (conditions(prg.stage))
        {
            nextButton.SetActive(true);
        }
    }
}
