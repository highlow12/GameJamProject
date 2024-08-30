using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator ani;
    public int money = 10;
    void Start(){
        ani = GetComponent<Animator>();
        ani.SetBool("spin", true);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.transform.CompareTag("Player")){
            GameManager.Instance.AddMoney(money);
            gameObject.SetActive(false);
        }
    }

}
