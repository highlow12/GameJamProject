using UnityEngine;

public class Endgame : MonoBehaviour
{
    // Quit ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ����� ���ø����̼ǿ����� Application.Quit()�� ȣ���Ͽ� ����
        Application.Quit();
#endif
    }
}
