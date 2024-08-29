using UnityEngine;
using UnityEngine.UI;

public class Music_Manager : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider volumeSlider;
    public GameObject optionsPanel;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        // �����̴��� ���� AudioSource�� �������� ����
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
        optionsPanel.SetActive(false); // ���� �� �г� ��Ȱ��ȭ
    }

    public void ToggleOptions()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }
}
