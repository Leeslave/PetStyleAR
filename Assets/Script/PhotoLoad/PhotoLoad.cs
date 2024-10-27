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

    // 갤러리에서 이미지 선택
    public void PickImageFromGallery()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                // 불러온 이미지를 텍스처로 로드
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize: 512);
                if (texture != null)
                {
                    displayImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                }
            }
        }, "Select an image", "image/*");

        check.gameObject.SetActive(true);
    }

    // 카메라로 사진 찍기
    public void TakePhoto()
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            if (path != null)
            {
                // 찍은 사진을 텍스처로 로드
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
