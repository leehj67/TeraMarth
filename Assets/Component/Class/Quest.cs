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
    public GameObject[] upgradeObjects;
    public ParticleSystem congratuation;

// 옥수수:   10초 재배
// 호박:     12초 재배
// 토마토:   8초 재배
// 당근:     16초 재배
// 양배추:   20초 재배
// 샐러드:   24초 재배
// 해바라기: 40초 재배
// 소:       50초 재배
// 닭:       40초 재배
// 양:       60초 재배
// 말:       120초 재배
// 염소:     75초 재배

    void Start()
    {
        quest = new string[prg.maxState + 1][];
        for (int i = 1; i <= quest.Length; i++)
        {
            if (i == 1) quest[i] = new string[] {
                "옥수수를 2회 심으세요.", "호박을 2회 심으세요.", "토마토를 2회 심으세요.", "당근을 2회 심으세요."
            };
            else if (i == 2) quest[i] = new string[] {
                "옥수수를 6회 수확하세요.", "토마토를 10회 수확하세요.", "소를 2회 기르세요.", "닭을 2회 기르세요."
            };
            else if (i == 3) quest[i] = new string[] {
                "양배추를 6번 수확하세요.", "샐러드를 6회 수확하세요.", "닭을 4회 도축하세요.", "양을 3회 도축하세요."
            };
            else if (i == 4) quest[i] = new string[] {
                "해바라기를 6회 수확하세요.", "소를 10회 도축하세요.", "말을 2회 도축하세요.", "염소를 3회 도축하세요."
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
            if (!questText[0].transform.Find("ClearLine").gameObject.activeSelf && hav.nofSet[0] >= 2)
            {
                questText[0].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[1].transform.Find("ClearLine").gameObject.activeSelf && hav.nofSet[1] >= 2)
            {
                questText[1].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[2].transform.Find("ClearLine").gameObject.activeSelf && hav.nofSet[2] >= 2)
            {
                questText[2].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[3].transform.Find("ClearLine").gameObject.activeSelf && hav.nofSet[3] >= 2)
            {
                questText[3].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            return clearLineActive(4);
        }
        else if (index == 2)
        {
            if (!questText[0].transform.Find("ClearLine").gameObject.activeSelf && hav.score[0] >= 6)
            {
                questText[0].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[1].transform.Find("ClearLine").gameObject.activeSelf && hav.score[2] >= 10)
            {
                questText[1].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[2].transform.Find("ClearLine").gameObject.activeSelf && hav.nofSet[7] >= 2)
            {
                questText[2].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[3].transform.Find("ClearLine").gameObject.activeSelf && hav.nofSet[8] >= 2)
            {
                questText[3].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            return clearLineActive(4);
        }
        else if (index == 3)
        {
            if (!questText[0].transform.Find("ClearLine").gameObject.activeSelf && hav.score[4] >= 6)
            {
                questText[0].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[1].transform.Find("ClearLine").gameObject.activeSelf && hav.score[5] >= 6)
            {
                questText[1].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[2].transform.Find("ClearLine").gameObject.activeSelf && hav.score[8] >= 4)
            {
                questText[2].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[3].transform.Find("ClearLine").gameObject.activeSelf && hav.score[9] >= 3)
            {
                questText[3].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            return clearLineActive(4);
        }
        else if (index == 4)
        {
            if (!questText[0].transform.Find("ClearLine").gameObject.activeSelf && hav.score[6] >= 6)
            {
                questText[0].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[1].transform.Find("ClearLine").gameObject.activeSelf && hav.score[7] >= 10)
            {
                questText[1].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[2].transform.Find("ClearLine").gameObject.activeSelf && hav.score[10] >= 2)
            {
                questText[2].transform.Find("ClearLine").gameObject.SetActive(true);
            }
            if (!questText[3].transform.Find("ClearLine").gameObject.activeSelf && hav.score[11] >= 3)
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
        congratuation.Play();

        if (cheat)
        {
            SceneManager.LoadScene(nextScene);
            return;
        }

        if(prg.stage == prg.maxState)
        {
            // 다음씬으로 이동
            SceneManager.LoadScene(nextScene);
            return;
        }
        
        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        upgradeObjects[prg.stage].SetActive(true);
        
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
