using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager: MonoBehaviour,ISaveManager
{
    public static PlayerManager instance;
    public Player player;

    public int currency;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this; 
        }
    }

    public bool HaveEnoughMoney(int _price)
    {
        if(_price > currency)
        {
            Debug.Log("not enough money");
            return false;
        }

        currency = currency - _price;

        return true;
    }

    public int GetCurrency() { return currency; }

    public void LoadData(GameData _data)
    {
        //Debug.Log("Load:Currency");
        this.currency = _data.currency;
    }

    public void SaveData(ref GameData _data)
    {
        _data.currency = this.currency;
    }
}
