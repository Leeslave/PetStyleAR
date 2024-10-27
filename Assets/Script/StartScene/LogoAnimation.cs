using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoAnimation : MonoBehaviour
{
    public Image logoImage;
    public Button loginButton;

    // 만약 추가 로그인 버튼 생성 시 로그인 버튼 컴포넌트 추가해야 함.

    void Start()
    {
        loginButton.gameObject.SetActive(false);
        
        StartCoroutine(MoveImageUp());
    }
    IEnumerator MoveImageUp()
    {
        yield return new WaitForSeconds(5.0f);
        Vector3 endPos = logoImage.rectTransform.localPosition; // 처음 배치한 위치
        Vector3 startPos = logoImage.rectTransform.anchoredPosition; // Anchor로 이동
        float duration = 2.0f; // 이동 시간
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            logoImage.rectTransform.anchoredPosition = Vector3.Slerp(startPos,endPos, elapsed / duration);
            yield return null;
        }
        loginButton.gameObject.SetActive(true);
        StartCoroutine(FadeInButton());
    }

    IEnumerator FadeInButton()
    {
        CanvasGroup canvasGroup = loginButton.gameObject.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        float duration = 1.0f; // 이동 시간
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1.0f, elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = 1.0f;

    }
}
