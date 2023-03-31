using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotManager : MonoBehaviour
{
    public static ItemSlotManager instance;

    [SerializeField] Sprite[] itemSprites;
    [SerializeField] ItemSlot[] itemSlots;
    int slotNum;
    Transform tr;

    private void Awake()
    {
        instance = this;
        tr = transform;
        slotNum = tr.childCount;
        for (int i = 0; i < slotNum; i++)
        {
            itemSlots[i] = tr.GetChild(i).GetComponent<ItemSlot>();
        }
    }

    public void AcquireItem(int _itemType)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].SlotFilled)
            {
                continue;
            }
            else
            {
                itemSlots[i].SetItem(_itemType);
            }
        }
    }

    public void UseItem()
    {
        itemSlots[0].ClearItem();
    }

    public Sprite GetItemSprite(int _idx)
    {
        if (_idx >= 0) return itemSprites[_idx];
        else return null;
    }
}