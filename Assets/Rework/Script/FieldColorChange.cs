using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldColorChange : MonoBehaviour
{
    private Color startTextColor = new Color32(0x2D, 0x2D, 0x2D, 0xFF); // #2D2D2D
    private Color targetTextColor = new Color32(0x65, 0x1F, 0xFF, 0xFF); // #651FFF
    private float duration = 1.0f;
    private TMP_Text text;

    public void ChangeTextColor()
    {
        text = gameObject.GetComponent<TMP_Text>();
        text.color = startTextColor;
        StartCoroutine(ChangingColor());
    }

    private IEnumerator ChangingColor()
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            text.color = Color.Lerp(startTextColor, targetTextColor, t);
            yield return null;
        }
        text.color = targetTextColor;

    }
}
