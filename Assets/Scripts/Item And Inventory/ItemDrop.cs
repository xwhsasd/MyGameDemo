
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{

    public int possibleItemDrop;
    public ItemData[] possibleDrop;
    [SerializeField] private float EnemyDropChance;
    [SerializeField] private GameObject dropPrefab;

    protected List<ItemData> dropList = new List<ItemData>();

    public virtual void GenerateDrop()
    {
        for (int i = 0; i < possibleDrop.Length; i++)
        {
            if(Random.Range(0,100)<= possibleDrop[i].dropChance * EnemyDropChance)
            {
                dropList.Add(possibleDrop[i]);
            }
        }

        for (int i = 0;i < possibleItemDrop && dropList.Count > 0; i++)
        {
            ItemData randomItem = dropList[Random.Range(0,dropList.Count - 1)];
            
            dropList.Remove(randomItem);
            DropItem(randomItem);
        }
    }

    protected void DropItem(ItemData _itemData)
    {
        GameObject newDrop = Instantiate(dropPrefab, transform.position,Quaternion.identity);

        Vector2 randomVelocity = new Vector2(Random.Range(-5, 5), Random.Range(15, 20));

        newDrop.GetComponent<ItemObject>().SetupItem(_itemData, randomVelocity);
    }
}
