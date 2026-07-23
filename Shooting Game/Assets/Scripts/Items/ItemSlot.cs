using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //item data
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;

    //item slot
    [SerializeField]
    private Image itemImage;

    //makes the item appear in the inventory and declares the item slot to be full
    public void AddItem(string itemName, Sprite itemSprite)
	{
	    this.itemName = itemName;
	    this.itemSprite = itemSprite;
	    isFull = true;

	    itemImage.sprite = itemSprite;
	}

    //empties the slot
    public void EmptySlot()
    {
        itemImage.sprite = null;
        itemName = null;
        isFull = false;
    }
}
