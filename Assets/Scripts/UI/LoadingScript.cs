using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScript : MonoBehaviour
{
    // 로드할 씬의 이름
    public string sceneToLoad;

    // ProgressBar를 나타내는 Slider UI 요소
    public Slider progressBar;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // 비동기 씬 로드를 시작
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false; // 자동 씬 전환을 비활성화

        while (!operation.isDone)
        {
            // 로드 프로그레스를 프로그레스 바에 반영 (0~1의 값)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;

            // 로드가 완료되었으나 씬 전환을 기다리고 있는 경우
            if (operation.progress >= 0.9f)
            {
                progressBar.value = 1f; // 프로그레스 바가 완전히 채워짐
                yield return new WaitForSeconds(5f); // 5초 대기
                operation.allowSceneActivation = true; // 씬 전환 허용
            }

            yield return null; // 다음 프레임까지 대기
        }
    }
}
