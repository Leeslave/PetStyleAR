using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private Sprite[] dogImages;
    [SerializeField] private Image image;
    [SerializeField] private GameObject register;
    private int index = 0;


    private void Start()
    {
        image.sprite = dogImages[0];
        //StartCoroutine(UpdateLoadingImages());
    }
    public void StartLoading()
    {
        StartCoroutine(UpdateLoadingImages());
        
    }

    private IEnumerator UpdateLoadingImages()
    {
        for (int i = 0; i < 15; i++)
        {
            image.sprite = dogImages[i % 3];
            yield return new WaitForSecondsRealtime(0.2f);
        }
        yield return new WaitForSecondsRealtime(3.0f);
        register.SetActive(true);
        gameObject.SetActive(false);
    }

}
