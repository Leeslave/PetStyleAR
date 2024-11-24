using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyButton : MonoBehaviour
{
    [SerializeField] private GameObject next;
    
    public void NextScene()
    {
        GameManager.Instance.PageChange(gameObject, next);
    }
}
