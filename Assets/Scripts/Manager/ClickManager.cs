using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(clickPos, Vector2.zero);
            RaycastHit2D hit = new();
            foreach (RaycastHit2D h in hits)
            {
                if (h.collider.CompareTag("Interactable"))
                {
                    hit = h;
                    break;
                }
            }
            if (hit.collider != null && hit.collider.CompareTag("Interactable"))
            {
                hit.collider.GetComponent<InteractableObject>().OnClick();
            }
        }
    }
}
