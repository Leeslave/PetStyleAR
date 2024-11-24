using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private Sprite[] dogImages;
    [SerializeField] private Image image;
    [SerializeField] private GameObject home;
    private int index = 0;


    private void Start()
    {
        image.sprite = dogImages[0];
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateLoadingImages());
    }

    private IEnumerator UpdateLoadingImages()
    {
        for (int i = 0; i < 16; i++)
        {
            image.sprite = dogImages[i % 3];
            yield return new WaitForSecondsRealtime(0.2f);
        }
        yield return new WaitForSecondsRealtime(0.1f);
        GameManager.Instance.PageChange(gameObject, home);
       
    }

}
