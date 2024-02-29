using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SkillToolTip : UI_Tooltip
{

    [SerializeField] private TextMeshProUGUI skillDescription;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI skillCost;

    //����AdjustFontSize����ʱ��������һ��
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
