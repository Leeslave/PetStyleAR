using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_003 : MonoBehaviour
{
    [SerializeField] private GameObject register;
    [SerializeField] private GameObject fitting;


    public void SetPage_Register()
    {
        GameManager.Instance.PageChange(gameObject, register);
    }

    public void SetPage_Fitting() 
    {
        GameManager.Instance.PageChange(gameObject, fitting);
    }
    
    // 나머지 메서드는 여기서 추가
}
