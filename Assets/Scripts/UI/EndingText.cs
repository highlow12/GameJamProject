using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndingText : MonoBehaviour
{
    public TMP_Text textMeshPro; // TMP 텍스트 컴포넌트
    public float typingSpeed = 0.1f; // 글자 출력 속도
    public float fadeDuration = 1f; // 페이드 시간
    
    void Start()
    {
    
        SetEndingText();
    }
    
    void SetEndingText()
    {
        StartCoroutine(HARDCORDING());
    }

    private void SetAlpha(float alpha)
    {
        Color color = textMeshPro.color;
        color.a = alpha;
        textMeshPro.color = color; // 알파 값 설정
    }
    
    IEnumerator HARDCORDING(){
        string OutText = "";
        OutText = "당신은 원단 재료를 고를 때\n";
        switch(GameManager.Instance.materialType){
            case MaterialType.Cotton:
                OutText += "환경에 보통인 면";
                break;
            case MaterialType.Leather:
                OutText +="환경오염이 심한 가죽";
                break;
            case MaterialType.Tencel:
                OutText +="친환경적인 텐셀";
                break;
        }
        OutText += "\n을(를) 선택 하였습니다.";

        string Text = OutText;

        foreach (char letter in Text.ToCharArray())
        {
            textMeshPro.text += letter; // 한 글자씩 추가
            yield return new WaitForSeconds(typingSpeed); // 지정한 시간만큼 대기
        }

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0); // 확실히 0으로 설정
        textMeshPro.text = "";
        // 알파 값을 0에서 1로 늘리기
        SetAlpha(1); // 확실히 1로 설정
        yield return new WaitForSeconds(0.5f);
        OutText = "원단 재료를 가공하며 생긴 폐기물을\n";
        if(GameManager.Instance.Minigame1Result == MinigameResult.Success){
            OutText += "친환경적으로";
        }else{
            OutText += "환경 파괴적으로";
        }
        OutText += "\n처리하였습니다.";
        Text = OutText;
        foreach (char letter in Text.ToCharArray())
        {
            textMeshPro.text += letter; // 한 글자씩 추가
            yield return new WaitForSeconds(typingSpeed); // 지정한 시간만큼 대기
        }

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0); // 확실히 0으로 설정
        textMeshPro.text = "";
        // 알파 값을 0에서 1로 늘리기
        SetAlpha(1); // 확실히 1로 설정
        yield return new WaitForSeconds(0.5f);

        OutText = "또한, 원단 배송을 위해\n";
        switch(GameManager.Instance.pojangType){
            case PojangType.Paper:
                OutText += "친환경적인 종이 포장재";
                break;
            case PojangType.Aircap:
                OutText +="환경에 좋지 않은 에어캡/";
                break;
            case PojangType.Vinil:
                OutText +="환경 오염이 심한 비닐";
                break;
        }
        OutText += "\n을(를) 선택 하였습니다.";

        Text = OutText;
        foreach (char letter in Text.ToCharArray())
        {
            textMeshPro.text += letter; // 한 글자씩 추가
            yield return new WaitForSeconds(typingSpeed); // 지정한 시간만큼 대기
        }

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0); // 확실히 0으로 설정
        textMeshPro.text = "";
        // 알파 값을 0에서 1로 늘리기
        SetAlpha(1); // 확실히 1로 설정
        yield return new WaitForSeconds(0.5f);

        OutText = "마지막으로 공장을 추가 건설할 때\n";
        if(GameManager.Instance.Minigame1Result == MinigameResult.Success){
            OutText += "산림을 파괴하며";
        }else{
            OutText += "빈 공터에";
        }
        OutText += "\n건설하였습니다.";
        Text = OutText;
        foreach (char letter in Text.ToCharArray())
        {
            textMeshPro.text += letter; // 한 글자씩 추가
            yield return new WaitForSeconds(typingSpeed); // 지정한 시간만큼 대기
        }

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0); // 확실히 0으로 설정
        textMeshPro.text = "";
        // 알파 값을 0에서 1로 늘리기
        SetAlpha(1); // 확실히 1로 설정
        yield return new WaitForSeconds(0.5f);
    }
}
