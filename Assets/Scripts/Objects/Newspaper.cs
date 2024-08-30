using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Newspaper : InteractableObject
{
    GameObject focusedObject;
    BoxCollider2D boxCollider2D;
    AudioSource audio;

    public Newspaper()
    {
        objectName = "Newspaper";
        isInteractable = true;
    }
    public void Awake()
    {
        focusedObject = transform.GetChild(0).gameObject;
        boxCollider2D = GetComponent<BoxCollider2D>();
        audio = GetComponent<AudioSource>();
    }
    public override void OnClick()
    {
        audio.Play();
        // pause the game time
        // Show the focused object
        isInteractable = false;
        GameManager.Instance.gameState = GameState.Select;
        focusedObject.SetActive(true);
        boxCollider2D.enabled = false;
    }
}
