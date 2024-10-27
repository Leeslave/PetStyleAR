using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Profile : MonoBehaviour
{
    public Image[] MainUI;
    public TMP_InputField[] InputFields;
    public TMP_Text errorText;

    public Image applyUI;
    public Button nextButton;
    public Button applyButton;

    private int index = 0;
    private bool isActive = false;

    private void Start()
    {
        for (int i = 0; i < MainUI.Length; i++)
        {
            MainUI[i].gameObject.SetActive(false);
        }
        MainUI[0].gameObject.SetActive(true);
        errorText.gameObject.SetActive(false);
        applyButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        applyUI.gameObject.SetActive(false);
    }

    public void NextImage()
    {
        MainUI[index].gameObject.SetActive(false);
        index++;
        MainUI[index].gameObject.SetActive(true);
        if (index == MainUI.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
            applyButton.gameObject.SetActive(true);
        }
    }
    public void Apply()
    {
        for (int i = 0; i < InputFields.Length; i++)
        {
            if (InputFields[i].text == "")
            {
                isActive = true;
            }
        }
        if (isActive)
        {
            errorText.gameObject.SetActive(true);
        }
        else
        {
            if (errorText.gameObject.activeSelf == true)
            {
                errorText.gameObject.SetActive(false);
            }
            CheckMessage();
        }
    }

    public void CheckMessage()
    {
        applyUI.gameObject.SetActive(true);
    }

    public void CancelUI()
    {
        applyUI.gameObject.SetActive(false);
    }
    public void nextScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
