using UnityEngine;

public class Endgame : MonoBehaviour
{
    // Quit 버튼이 눌렸을 때 호출되는 메서드
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 애플리케이션에서는 Application.Quit()을 호출하여 종료
        Application.Quit();
#endif
    }
}
