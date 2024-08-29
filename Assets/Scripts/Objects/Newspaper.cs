using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Newspaper : InteractableObject
{
    GameObject focusedObject;
    SpriteRenderer spriteRenderer;

    public Newspaper()
    {
        objectName = "Newspaper";
    }
    public void Awake()
    {
        focusedObject = transform.GetChild(0).gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void OnClick()
    {
        // pause the game time
        // Show the focused object

        GameManager.Instance.gameState = GameState.Select;
        focusedObject.SetActive(true);
        spriteRenderer.enabled = false;
    }
}
