using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DogRegistManager : MonoBehaviour
{
    [SerializeField] private QuestionList ql;
    [SerializeField] private Image[] fields;
    [SerializeField] private Image[] frames;
    [SerializeField] GameObject next;
    [SerializeField] private BoxText[] fieldsText;


    private float elapsedTime;
    private float fadeDuration;
    private int index = 0;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                frames[i].gameObject.SetActive(true);
                fields[i].gameObject.SetActive(true);
                fieldsText[2 * i].gameObject.SetActive(true);
                fieldsText[2 * i + 1].gameObject.SetActive(true);
            }
            else
            {
                frames[i].gameObject.SetActive(false);
                fields[i].gameObject.SetActive(false);
                fieldsText[2 * i].gameObject.SetActive(false);
                fieldsText[2 * i + 1].gameObject.SetActive(false);
            }
            
        }
    }
    public void NextStatue()
    {
        if (index == fields.Length - 1)
        {
            GameManager.Instance.PageChange(gameObject, next);
            return;
        }
        index++;
        frames[index].gameObject.SetActive(true);
        StartCoroutine(FadeInImage(index));
        ql.ChangeQuestion(index);
    }

    private IEnumerator FadeInImage(int index)
    {
        Debug.Log(index);
        elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            // �ؽ�Ʈ ���� �� ������ ����
            Color color = fields[index-1].color;
            color.a = t;
            fields[index-1].color = color;

            yield return null;
        }
        // ���� �� 1���� ����
        Color finalColor = fields[index-1].color;
        finalColor.a = 1;
        fields[index-1].color = finalColor;
        if (index < 3)
        {

            fields[index].gameObject.SetActive(true);
            fieldsText[2 * index].gameObject.SetActive(true);
            fieldsText[2 * (index - 1)].ChangeTextColor();
            fieldsText[2 * index + 1].gameObject.SetActive(true);
            fieldsText[2 * (index - 1) + 1].ChangeTextColor();
        }
        else
        {
            fieldsText[2 * (index - 1)].ChangeTextColor();
            fieldsText[2 * (index - 1) + 1].ChangeTextColor();
        }


    }
}
