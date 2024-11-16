using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionList : MonoBehaviour
{
    [SerializeField] string[] dialogs;
    [SerializeField] TMP_Text text;
    float elapsedTime = 0;

    private float fadeDuration = .5f;

    public void ChangeQuestion(int idx)
    {
        StartCoroutine(ChangeStatus(idx));
    }

    private IEnumerator ChangeStatus(int index)
    {
        if (index < 3)
        {
            yield return FadeOutText();
            text.text = dialogs[index];
            yield return FadeInText();
        }
    }

    private IEnumerator FadeOutText()
    {
        elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            // 텍스트 알파 값 서서히 감소
            Color color = text.color;
            color.a = 1 - t;
            text.color = color;

            yield return null;
            yield return null;
        }

        // 알파 값 0으로 고정
        Color finalColor = text.color;
        finalColor.a = 0;
        text.color = finalColor;

    }

    private IEnumerator FadeInText()
    {
        elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            // 텍스트 알파 값 서서히 감소
            Color color = text.color;
            color.a = t;
            text.color = color;

            yield return null;
        }
        // 알파 값 1으로 고정
        Color finalColor = text.color;
        finalColor.a = 1;
        finalColor.a = 1;
        text.color = finalColor;
    }
}
