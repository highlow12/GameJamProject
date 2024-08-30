using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseButton : InteractableObject
{
    AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    public CloseButton()
    {
        objectName = "CloseButton";
    }
    public override void OnClick()
    {
        _audio.Play();
        // Close the parent object
        transform.parent.gameObject.SetActive(false);
        // Resume the game time
        GameManager.Instance.gameState = GameState.Running;
    }
}
