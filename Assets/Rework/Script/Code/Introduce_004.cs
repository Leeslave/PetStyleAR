using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduce_004 : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject[] images;
    [SerializeField] private GameObject nextScene;
    private float elapsedTime;
    private float fadeDuration = 0.5f;
    private int index = 0;

    private void Start()
    {
        for(int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
        images[0].SetActive(true);
    }

    public void NextImage()
    {
        Debug.Log("NextImage");
        if (index < images.Length - 1)
        {
            StartCoroutine(Changing(images[index], images[index + 1]));
            index++;
        }
        else
        {
            NextScene();
        }
    }
    private void NextScene()
    {
        GameManager.Instance.PageChange(gameObject, nextScene);
    }


    private IEnumerator Changing(GameObject now, GameObject target)
    {
        yield return FadeOut();
        now.SetActive(false);
        target.SetActive(true);
        yield return FadeIn();
    }

    private IEnumerator FadeIn()
    {
        elapsedTime = 0;
        canvasGroup.alpha = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        // 최종 보정
        canvasGroup.alpha = 1f;
    }

    private IEnumerator FadeOut()
    {
        elapsedTime = 0;
        canvasGroup.alpha = 1f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(1 - elapsedTime / fadeDuration);
            yield return null;
        }

        // 최종 보정
        canvasGroup.alpha = 0f;
    }
}
