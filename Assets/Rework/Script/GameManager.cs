using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if ( null == instance )
            {
                GameObject go = new GameObject("GameManager");
                instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private CanvasGroup canvasGroup;
    private float fadeDuration = 0.5f;
    private float elapsedTime = 0f;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void PageChange(GameObject now, GameObject target)
    {
        StartCoroutine(Changing(now, target));
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
