using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingScript : MonoBehaviour
{
    public GameObject ball;
    public GameObject arrow;
    public float ballSpeed = 1f;
    public float rotateSpeed = 1f;
    
    Vector3 startPos;
    Vector3 endPos;
    Vector3 direction;
    Transform arrowTrans;


    
    bool isDragging = false;


    void Awake()
    {
        arrowTrans = arrow.GetComponent<Transform>();
    }

    void Update()
    {
        if(isDragging){
            direction = endPos-startPos;
            DragArrow();
        }
        DragFunction();
    }

    void DragFunction(){
        if(Input.GetMouseButtonDown(0)){
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
            Debug.Log("Start Dragging");
        }
        if(Input.GetMouseButtonUp(0)&&isDragging){
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Shot();
            Debug.Log("Ended Dragging");

        }
    }
    void Shot(){
        GameObject newBall = Instantiate(ball, transform.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody2D>().AddForce((direction)*ballSpeed*-1, ForceMode2D.Impulse);
        isDragging = false;
    }

    void DragArrow(){
        //위에서 구한 목표 방향(Vector3)을 사분위수로 전환하는 메서드
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        //(시작값, 목표값, 회전 속도)를 인자로 받아 회전 값을 연산해주는 메서드
        Quaternion rotateAmount = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        //회전값 적용
        arrowTrans.rotation = rotateAmount;
        
    }

}
