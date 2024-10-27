using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotoLoad : MonoBehaviour
{
    public Image displayImage;
    public Image check;


    private void Start()
    {
        check.gameObject.SetActive(false);
    }

    // ���������� �̹��� ����
    public void PickImageFromGallery()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                // �ҷ��� �̹����� �ؽ�ó�� �ε�
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize: 512);
                if (texture != null)
                {
                    displayImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                }
            }
        }, "Select an image", "image/*");

        check.gameObject.SetActive(true);
    }

    // ī�޶�� ���� ���
    public void TakePhoto()
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            if (path != null)
            {
                // ���� ������ �ؽ�ó�� �ε�
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize: 512);
                if (texture != null)
                {
                    displayImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                }
            }
        }, maxSize: 512);


        check.gameObject.SetActive(true);
    }

    public void CancelPhoto()
    {
        check.gameObject.SetActive(false);
    }

    public void LoadSizeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);  
    }
}
