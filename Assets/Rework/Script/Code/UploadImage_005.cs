using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UploadImage_005 : MonoBehaviour
{
    [SerializeField] GameObject deactivateButton;
    [SerializeField] GameObject activateButton;
    [SerializeField] GameObject next;
    [SerializeField] Image[] displayImages;
    [SerializeField] Image displayImage;
    private int fillCount = 0;

    private void Start()
    {
        activateButton.SetActive(false);
        deactivateButton.SetActive(true);
    }
    //public void PickImageFromGallery()
    //{
    //    NativeGallery.Permission permission = NativeGallery.GetImagesFromGallery((paths) =>
    //    {
    //        if (paths != null && paths.Length > 0)
    //        {
    //            for (int i = 0; i < paths.Length; i++)
    //            {
    //                string path = paths[i];

    //                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize: 512);
    //                if (texture != null)
    //                {
    //                    displayImages[i].sprite = Sprite.Create(
    //                    texture,
    //                    new Rect(0, 0, texture.width, texture.height),
    //                    Vector2.zero
    //                    );
    //                }
    //                else
    //                {
    //                    Debug.LogWarning($"�̹����� �ε��� �� �����ϴ�: {path}");
    //                }
    //            }
    //        }
    //    }, "Select an image", "image/*");
    //}

    public void PickImageFromGallery(int index)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                // �ҷ��� �̹����� �ؽ�ó�� �ε�
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize: 512);
                if (texture != null)
                {
                    displayImages[index].sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                }
            }
        }, "Select an image", "image/*");
        fillCount++;
        ActivateNextButton();
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
        fillCount++;
        ActivateNextButton();
    }

    private void ActivateNextButton()
    {
        if (fillCount == 3)
        {
            deactivateButton.SetActive(false);
            activateButton.SetActive(true);
        }
    }
    public void NextScene()
    {
        GameManager.Instance.PageChange(gameObject, next);
    }
}
