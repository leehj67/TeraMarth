using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneLoader : MonoBehaviour
{
    public float delayInSeconds = 5.0f; // 지연 시간, 초 단위
    public string sceneToLoad = "NextScene"; // 로드할 씬의 이름

    void Start()
    {
        // 코루틴 시작
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        // 지정된 시간만큼 대기
        yield return new WaitForSeconds(delayInSeconds);

        // 씬 로드
        SceneManager.LoadScene(sceneToLoad);
    }
}
