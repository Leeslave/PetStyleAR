using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityFigmaBridge.Runtime.UI;
using TMPro;

public class LogoMove : MonoBehaviour
{
    [SerializeField] GameObject slogan; // ���ΰ� �̹���
    [SerializeField] Image logoImage;
    [SerializeField] Image registerButton;
    [SerializeField] Image logInButton;
    [SerializeField] GameObject Login;
    [SerializeField] GameObject Register;
    private float moveDuration = 1.0f; // ���ΰ� �̵� �ð�
    private float fadeDuration = 1.0f; // �ΰ� ���̵� �� �ð�
    [SerializeField] LoadingUI lui;

    private RectTransform sloganRectTransform;


    void Start()
    {
        sloganRectTransform = slogan.GetComponent<RectTransform>();
        Login.SetActive(false);
        Register.SetActive(false);


        // ó�� �ΰ� �̹����� ���� �� 0���� ����
        Color logoColor = logoImage.color;
        logoColor.a = 0;
        logoImage.color = logoColor;
        registerButton.color = logoColor;
        logInButton.color = logoColor; 

        // �ڷ�ƾ ����
        StartCoroutine(PlayIntroSequence());
    }

    IEnumerator PlayIntroSequence()
    {
        // ���ΰ� �̵� �ڷ�ƾ ����
        yield return StartCoroutine(MoveSlogan());

        // �ΰ� ���̵� �� �ڷ�ƾ ����
        yield return StartCoroutine(FadeInLogo());

        // �α���, ȸ������ ��ư ���̵� �� �ڷ�ƾ ����
        yield return StartCoroutine(FadeInButton());
    }

    IEnumerator MoveSlogan()
    {
        Vector3 startPosition = new Vector3(0, 0, 0);
        Vector3 endPosition = new Vector3(0, 250, 0);
        float elapsedTime = 0;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);

            // Slerp�� ����� ��ġ ����
            sloganRectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        sloganRectTransform.anchoredPosition = endPosition;
    }

    IEnumerator FadeInButton()
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            Color color = logoImage.color;
            color.a = t;
            registerButton.color = color;
            logInButton.color = color;

            yield return null;
        }

        // ���� �� 1�� ����
        Color finalColor = registerButton.color;
        finalColor.a = 1;
        registerButton.color = finalColor;
        logInButton.color = finalColor;
        Login.SetActive(true);
        Register.SetActive(true);
    }
    IEnumerator FadeInLogo()
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            Color color = logoImage.color;
            color.a = t;
            logoImage.color = color;

            yield return null;
        }

        // ���� �� 1�� ����
        Color finalColor = logoImage.color;
        finalColor.a = 1;
        logoImage.color = finalColor;
    }

    public void SwapImage()
    {
        //lui.gameObject.SetActive(true);
        GetComponentInParent<UIFadeController>().ScreenChange(gameObject, lui.gameObject);
        //lui.StartLoading();
        //gameObject.SetActive(false);
    }
}
