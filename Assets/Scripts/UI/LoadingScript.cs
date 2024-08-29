using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScript : MonoBehaviour
{
    // �ε��� ���� �̸�
    public string sceneToLoad;

    // ProgressBar�� ��Ÿ���� Slider UI ���
    public Slider progressBar;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // �񵿱� �� �ε带 ����
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false; // �ڵ� �� ��ȯ�� ��Ȱ��ȭ

        while (!operation.isDone)
        {
            // �ε� ���α׷����� ���α׷��� �ٿ� �ݿ� (0~1�� ��)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.value = progress;

            // �ε尡 �Ϸ�Ǿ����� �� ��ȯ�� ��ٸ��� �ִ� ���
            if (operation.progress >= 0.9f)
            {
                progressBar.value = 1f; // ���α׷��� �ٰ� ������ ä����
                yield return new WaitForSeconds(5f); // 5�� ���
                operation.allowSceneActivation = true; // �� ��ȯ ���
            }

            yield return null; // ���� �����ӱ��� ���
        }
    }
}
