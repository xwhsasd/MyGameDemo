using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SkillToolTip : UI_Tooltip
{

    [SerializeField] private TextMeshProUGUI skillDescription;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI skillCost;

    //启用AdjustFontSize函数时，启用下一行
    //[SerializeField] private float defaultNameFontSize;

    public void ShowToolTip(string _skillName,string _skillDescription,int _skillCost)
    {
        skillName.text = _skillName;
        skillDescription.text = _skillDescription;
        skillCost.text = "Cost: " + _skillCost;

        AdjustPosition();

        //AdjustFontSize();

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        //skillName.fontSize = defaultNameFontSize;
        gameObject.SetActive(false);
    }
}
