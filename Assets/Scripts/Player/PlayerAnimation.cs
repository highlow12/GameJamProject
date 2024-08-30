using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public  Animator animator;
    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    void Start(){
        GameManager.Instance.runningAction += SetWalkTrue;
        GameManager.Instance.selectAction += SetWalkFalse;
        GameManager.Instance.eventAction += SetWalkFalse;
    }
    // Start is called before the first frame update
    public void SetWalkTrue()
    {
        animator.SetBool("Walk",true);
        audio.mute = false;
    }
    public void SetWalkFalse()
    {
        animator.SetBool("Walk",false);
        audio.mute = true;
    }
}
