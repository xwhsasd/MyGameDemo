using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestItemDrop : ItemDrop
{
    private Chest chest;
    public string id = " ";
    public bool isOpen = false;

    private void Awake()
    {
        chest = GetComponent<Chest>();
        if (id == " ")
            GenerateId();
    }

    private void OnValidate()
    {
        gameObject.name = "Chest Wooden + " + possibleDrop[0].itemName ;
    }

    [ContextMenu("Generate checkpoint id")]
    private void GenerateId()
    {
        id = System.Guid.NewGuid().ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen)
            return;
        if (collision.GetComponent<Player>() != null)
        {
            chest.Open();
            isOpen = true;
            GenerateDrop();
        }

    }

    public void OpenChest()
    {
        isOpen = true;
        chest.Open();
    }

    public override void GenerateDrop()
    {
        for (int i = 0; i < possibleDrop.Length; i++)
        {
            dropList.Add(possibleDrop[i]);
        }

        for (int i = 0; i < possibleItemDrop && dropList.Count > 0; i++)
        {
            DropItem(dropList[i]);
            dropList.Remove(dropList[i]);
        }
    }
}
