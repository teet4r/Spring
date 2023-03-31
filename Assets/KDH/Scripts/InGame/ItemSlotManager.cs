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
        itemSlots = new ItemSlot[slotNum];
        for (int i = 0; i < slotNum; i++)
        {
            itemSlots[i] = tr.GetChild(i).GetComponent<ItemSlot>();
        }
    }

    // AcquireItem(int) ���ڿ� �ش��ϴ� ��ȣ�� ���� �������� ȹ���Ѵ�.
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
                break;
            }
        }
    }

    // UseItem() ù ��° ���Կ� �ִ� �������� ����ϰ� �� ���Ծ� ����.
    public void UseItem()
    {
        itemSlots[0].ClearItem();
        for (int i = 0; i < itemSlots.Length - 1; i++)
        {
            itemSlots[i].SetItem(itemSlots[i + 1].ItemType);
        }
        itemSlots[itemSlots.Length - 1].ClearItem();
    }

    // GetItemSprite(int) ���ڿ� �ش��ϴ� ��ȣ�� ���� �������� ��������Ʈ�� ��ȯ�Ѵ�.
    public Sprite GetItemSprite(int _itemType)
    {
        if (_itemType >= 0) return itemSprites[_itemType];
        else return null;
    }
}