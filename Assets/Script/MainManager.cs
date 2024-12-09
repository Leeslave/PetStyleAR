using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private bool view;
    [SerializeField] XROrigin xrOrigin;
    [SerializeField] Camera targetCamera;
    private Vector2 previousTouchPosition;
    private bool isTouching = false;
    [SerializeField] GameObject dog;

    // ȸ�� �ӵ� ����
    public float rotationSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera.gameObject.SetActive(false);    
    }

    public void Activate()
    {
        xrOrigin.gameObject.SetActive(false);
        targetCamera.gameObject.SetActive(true);
        view = true;
    }

    public void Deactivate()
    {
        xrOrigin.gameObject.SetActive(true);
        targetCamera.gameObject.SetActive(false);
        view = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ�� ����
        {
            isTouching = true;
            previousTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0) && isTouching) // ���콺 �巡�� ��
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 deltaPosition = currentMousePosition - previousTouchPosition;

            // ������Ʈ ȸ��
            //float rotationX = deltaPosition.y * rotationSpeed;
            float rotationY = -deltaPosition.x * rotationSpeed;

            dog.transform.Rotate(0, rotationY, 0, Space.World);

            previousTouchPosition = currentMousePosition; // ���� ��ġ�� ���� ��ġ�� ����
        }
        else if (Input.GetMouseButtonUp(0)) // ���콺 Ŭ�� ����
        {
            isTouching = false;
        }
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    switch (touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            isTouching = true;
        //            previousTouchPosition = touch.position;
        //            break;

        //        case TouchPhase.Moved:
        //            if (isTouching)
        //            {
        //                // ��ġ �̵� �Ÿ� ���
        //                Vector2 deltaPosition = touch.deltaPosition;

        //                // ������Ʈ ȸ��
        //                float rotationX = deltaPosition.y * rotationSpeed;
        //                float rotationY = -deltaPosition.x * rotationSpeed;

        //                transform.Rotate(rotationX, rotationY, 0, Space.World);
        //            }
        //            break;

        //        case TouchPhase.Ended:
        //        case TouchPhase.Canceled:
        //            isTouching = false;
        //            break;
        //    }
        //}
    }
}
