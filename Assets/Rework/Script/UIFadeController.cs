using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 0.5f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ScreenChange(GameObject now, GameObject next)
    {
        StartCoroutine(Changing(now, next));
    }

    private IEnumerator Changing(GameObject now, GameObject next)
    {
        yield return FadeOut();
        now.SetActive(false);
        next.SetActive(true);
        yield return FadeIn();
    }
    
    private IEnumerator FadeIn()
    {
        Debug.Log("Fade In");
        float elapsedTime = 0f;
        canvasGroup.alpha = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
    private IEnumerator FadeOut()
    {
        Debug.Log("Fade Out");
        float elapsedTime = 0f;
        canvasGroup.alpha = 1f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(1 - elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}
