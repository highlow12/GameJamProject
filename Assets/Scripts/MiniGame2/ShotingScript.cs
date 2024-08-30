using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingScript : MonoBehaviour
{
    public GameObject[] ball;
    public GameObject arrow;
    public float ballSpeed = 1f;
    public int curBallNum = 0;
    public float endingTime = 5f;
    
    Vector3 startPos;
    Vector3 endPos;
    Vector3 direction;
    Transform arrowTrans;

    float angle;
    
    bool isDragging = false;
    bool isGameEnding = false;
    SpriteRenderer arrowSprite;


    void Awake()
    {
        arrowTrans = arrow.GetComponent<Transform>();
        arrowSprite = arrow.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(isGameEnding){
            return;
        }
        if(isDragging){
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)-startPos;
            DragArrow();
        }
        DragFunction();
        //ray
        Debug.DrawRay(transform.position, direction*-1, Color.red);
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
            isDragging = false;
        }
    }
    void Shot(){
        Debug.Log("Shot");
        //GameObject newBall = Instantiate(ball, transform.position, Quaternion.identity);
        ball[curBallNum].transform.position = transform.position;
        ball[curBallNum].SetActive(true);
        ball[curBallNum].GetComponent<Rigidbody2D>().AddForce((endPos-startPos)*ballSpeed*-1, ForceMode2D.Impulse);
        ball[curBallNum].GetComponent<BallScript>().StartCoroutine("StopBall");
        curBallNum++;
        if(curBallNum>=3){
            StartCoroutine("endingTimer");
        }
    }
    IEnumerator endingTimer(){
        isGameEnding = true;
        yield return new WaitForSeconds(endingTime);
        for(int i = 0; i<curBallNum; i++){
            Destroy(ball[i]);
        }
        BuildingFactoriesMinigame.Instance.OnEventEnd();
    }

    void DragArrow(){
    
        angle = Quaternion.FromToRotation(new Vector3(0,100,0), direction*-1).eulerAngles.z;
        //Debug.Log(angle);
        arrowTrans.rotation = Quaternion.Euler(0, 0, angle);
        arrowSprite.color = new Color(255, 0, 0, direction.magnitude/10);
        //arrowTrans.localScale = new Vector3(0.8f, direction.magnitude, 1);
        //direction.magnitude만큼 색의 강도를 조절하거나 효과음을 변경시키면 좋을듯
    }

}
