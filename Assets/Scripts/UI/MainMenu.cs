using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // �ε� ������ ��ȯ
        SceneManager.LoadScene("Loading");
    }
}
