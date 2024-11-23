using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_001 : MonoBehaviour
{
    [SerializeField] GameObject slogan;
    [SerializeField] Image logo;
    [SerializeField] GameObject login;
    [SerializeField] GameObject register;

    private Image logoImage;
    private Image loginButtonImage;
    private Image registerButtonImage;

    // 슬로건 UI 이동
    private RectTransform logoTransform;
    
    private float duration = 1.0f;
    private float elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        logoTransform = slogan.GetComponent<RectTransform>();
        loginButtonImage = login.GetComponent<Image>();
        registerButtonImage = register.GetComponent<Image>();

        Color logoColor = logo.color;
        logoColor.a = 0;
        logo.color = logoColor;
        loginButtonImage.color = logoColor;
        registerButtonImage.color = logoColor;

        login.SetActive(false);
        register.SetActive(false);

        StartCoroutine(PlayIntroSequence());
    }

    IEnumerator PlayIntroSequence()
    {
        // 슬로건 이동 코루틴 실행
        yield return StartCoroutine(MoveSlogan());

        // 로고 페이드 인 코루틴 실행
        yield return StartCoroutine(FadeInLogo());

        // 로그인, 회원가입 버튼 페이드 인 코루틴 실행
        yield return StartCoroutine(FadeInButton());
    }

    IEnumerator MoveSlogan()
    {
        Vector3 startPosition = new Vector3(0, 0, 0);
        Vector3 endPosition = new Vector3(0, 250, 0);
        elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Slerp를 사용한 위치 보간
            logoTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        logoTransform.anchoredPosition = endPosition;
    }

    IEnumerator FadeInButton()
    {
        elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            Color color = logoImage.color;
            color.a = t;
            loginButtonImage.color = color;
            registerButtonImage.color = color;
            
            yield return null;
        }

        // 알파 값 1로 고정
        Color finalColor = registerButtonImage.color;
        finalColor.a = 1;
        registerButtonImage.color = finalColor;
        loginButtonImage.color = finalColor;
        login.SetActive(true);
        register.SetActive(true);
    }
    IEnumerator FadeInLogo()
    {
        elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            Color color = logoImage.color;
            color.a = t;
            logoImage.color = color;

            yield return null;
        }

        // 알파 값 1로 고정
        Color finalColor = logoImage.color;
        finalColor.a = 1;
        logoImage.color = finalColor;
    }
}
