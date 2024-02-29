using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickItem_Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myText;
    private Image image;


    [SerializeField] private float speed;
    [SerializeField] private float desapearanceSpeed;
    [SerializeField] private float colorDesapearanceSpeed;

    [SerializeField] private float lifeTime;

    private float textTimer;
    private RectTransform rectTransform;


    private Vector3 initialPosition;
    private bool canMove = false;
    public bool canBeFilled = true;

    private void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        image = GetComponentInChildren<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        initialPosition = rectTransform.position;
        myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, 0);
        image.color = myText.color;
    }

    private void Update()
    {
        if(canMove)
            MoveTooltip();
    }

    private void MoveTooltip()
    {
        rectTransform.position = Vector2.MoveTowards(rectTransform.position, new Vector2(rectTransform.position.x, rectTransform.position.y + 1), speed * Time.deltaTime);
        textTimer -= Time.deltaTime;

        if (textTimer < 0)
        {
            float alpha = myText.color.a - colorDesapearanceSpeed * Time.deltaTime;
            myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, alpha);
            image.color = myText.color;


            if (myText.color.a < 50)
                speed = desapearanceSpeed;

            if (myText.color.a <= 0)
            {
                canMove = false;
                canBeFilled = true;
            }
        }
    }

    public void GetInfo(ItemData _item)
    {
        textTimer = lifeTime;
        myText.text = _item.itemName;
        image.sprite = _item.icon;
        canMove = true;
        rectTransform.position = initialPosition;
        myText.color = Color.white;
        image.color = Color.white;
    }
}
