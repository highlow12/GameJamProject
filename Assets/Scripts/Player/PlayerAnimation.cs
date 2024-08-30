using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    void Start()
    {
        GameManager.Instance.runningAction += SetWalkTrue;
        GameManager.Instance.selectAction += SetWalkFalse;
        GameManager.Instance.eventAction += SetWalkFalse;
    }
    // Start is called before the first frame update
    public void SetWalkTrue()
    {
        animator.SetBool("Walk", true);
    }
    public void SetWalkFalse()
    {
        animator.SetBool("Walk", false);
    }
}
