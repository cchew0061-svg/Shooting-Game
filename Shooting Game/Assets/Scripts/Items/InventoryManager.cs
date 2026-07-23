using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot[] itemSlot;
    public bool pickedUp = false;

    public Items[] items;

    public GameObject inventoryFullUI;

    private Interactables interactables;

    //uses items if held in inventory
    public void UseItem(string itemName)
    {
	    for(int j = 0; j < 4; j++)
	    {
			if(itemName == itemSlot[j].itemName)
			{
				switch(itemName)
				{
					case "Medical Kit":
						items[0].UseItem();
						break;
					case "Green Ammunition":
						items[1].UseItem();
						break;
					case "Blue Ammunition":
						items[2].UseItem();
						break;
				}
				itemSlot[j].EmptySlot();
				return;
			}
	    }
    }

    //adds item to the inventory if the inventory has open slots
    public void AddItem(string itemName, Sprite itemSprite)
    {
		for(int i = 0; i < itemSlot.Length; i++)
		{
			if(itemSlot[i].isFull == false)
			{
				itemSlot[i].AddItem(itemName, itemSprite);
				pickedUp = true;
				return;
			}
		}
		//starts the coroutine if the item has not been picked up due to a lack of inventory space
		StartCoroutine(ShowInventoryFullUI());
    }

    //provides a message for 2 seconds if inventory is full and player tries to pick up an object
    private IEnumerator ShowInventoryFullUI()
    {
		inventoryFullUI.gameObject.SetActive(true);
		yield return new WaitForSeconds(2f);
		inventoryFullUI.gameObject.SetActive(false);
    }
}
