using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image image;
    int itemType = -1;

    public int ItemType { get { return itemType; } }
    public bool SlotFilled { get { if (itemType == -1) return false; else return true; } }

    private void Awake()
    {
        SetImageInvisible();
    }

    void SetImageInvisible()
    {
        Color color = image.color;
        color.a = 0f;
        image.color = color;
    }

    void SetImageVisible()
    {
        Color color = image.color;
        color.a = 1f;
        image.color = color;
    }

    void SetImage()
    {
        image.sprite = ItemSlotManager.instance.GetItemSprite(itemType);
    }

    public void SetItem(int _itemType)
    {
        itemType = _itemType;
        SetImage();
        SetImageVisible();
    }

    public void ClearItem()
    {
        itemType = -1;
        image.sprite = null;
        SetImageInvisible();
    }
}