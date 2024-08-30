using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioSource audio;
    Animator ani = null;
    public int money = 10;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    void Start(){
        if(ani!=null){
            ani = GetComponent<Animator>();
            ani.SetBool("spin", true);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.transform.CompareTag("Player")){
            GameManager.Instance.AddMoney(money);
            audio.Play();
            gameObject.SetActive(false);
        }
    }

}
