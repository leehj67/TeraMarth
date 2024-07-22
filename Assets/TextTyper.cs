using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI 네임스페이스 추가

public class TextTyper : MonoBehaviour
{
    public TMP_Text textComponent; // TMP 텍스트 컴포넌트 참조
    public string message = "여기에 표시할 메시지를 입력하세요."; // 표시할 메시지
    public float typingSpeed = 0.2f; // 글자가 표시되는 속도 (초)
    public Button continueButton; // 활성화할 버튼

    private void Start()
    {
        continueButton.gameObject.SetActive(false); // 버튼을 초기에 비활성화
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = ""; // 텍스트 초기화
        int charCount = 0; // 글자 수를 카운트하기 위한 변수

        foreach (char letter in message.ToCharArray())
        {
            textComponent.text += letter; // 글자 하나씩 추가
            charCount++; // 글자 수 증가
            if (charCount % 10 == 0) // 10글자마다 줄바꿈
            {
                textComponent.text += '\n'; // 줄바꿈 추가
            }
            yield return new WaitForSeconds(typingSpeed); // 다음 글자 표시 전 대기
        }
        continueButton.gameObject.SetActive(true); // 모든 텍스트가 표시된 후 버튼 활성화
    }
}
