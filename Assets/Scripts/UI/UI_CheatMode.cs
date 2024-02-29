using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CheatMode : MonoBehaviour
{
    [SerializeField] private UI ui;
    [SerializeField] private Player player;

    public Toggle cheatMode;

    void Start()
    {
        cheatMode.onValueChanged.AddListener(OnCheatToggleValueChanged);
    }

    private void OnCheatToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            ui.OpenCheatMode();
            player.OpenCheatMode();
        }
        else
        {
            ui.CloseCheatMode();
            player.CloseCheatMode();
        }
    }
}
