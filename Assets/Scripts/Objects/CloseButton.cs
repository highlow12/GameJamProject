using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseButton : InteractableObject
{

    public CloseButton()
    {
        objectName = "CloseButton";
    }
    public override void OnClick()
    {
        // Close the parent object
        transform.parent.gameObject.SetActive(false);
        // Resume the game time
        GameManager.Instance.gameState = GameState.Running;
    }
}
