using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // 로딩 씬으로 전환
        SceneManager.LoadScene("Loading");
    }
}
