using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Tooltip : MonoBehaviour
{
    [SerializeField] private float xLimit = 960;
    [SerializeField] private float yLimit = 540;

    [SerializeField] private float xOffset = 150;
    [SerializeField] private float yoffset = 150;


    public virtual void AdjustPosition()
    {
        Vector2 mousePosition = Input.mousePosition;

        float newXoffset = 0;
        float newYoffset = 0;

        if (mousePosition.x > xLimit)
            newXoffset = -xOffset;
        else
            newXoffset = xOffset;

        if (mousePosition.y > yLimit)
            newYoffset = -yoffset;
        else
            newYoffset = yoffset;

       transform.position = new Vector2(mousePosition.x + newXoffset, mousePosition.y + newYoffset);
    }

    public void AdjustFontSize(TextMeshProUGUI _text)
    {
        if (_text.text.Length > 12)
        {
            _text.fontSize = _text.fontSize * 0.8f;
        }
    }

}
