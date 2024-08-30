using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Newspaper : InteractableObject
{
    public static Newspaper Instance;
    GameObject focusedObject;
    BoxCollider2D boxCollider2D;
    [SerializeField]
    private AudioSource _audio;

    public Newspaper()
    {
        objectName = "Newspaper";
        isInteractable = false;
    }
    public void Awake()
    {
        Instance = this;
        focusedObject = transform.GetChild(0).gameObject;
        boxCollider2D = GetComponent<BoxCollider2D>();
        _audio = GetComponent<AudioSource>();
    }
    public override void OnClick()
    {
        // _audio.Play();
        // pause the game time
        // Show the focused object
        if (!isInteractable)
        {
            return;
        }
        isInteractable = false;
        GameManager.Instance.gameState = GameState.Select;
        focusedObject.SetActive(true);
        boxCollider2D.enabled = false;
    }
}
