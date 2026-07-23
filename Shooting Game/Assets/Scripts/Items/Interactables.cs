using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    //message displayed when looking at an interactable object
    public string promptMessage;

    [SerializeField]
    private string itemName;
    [SerializeField]
    private Sprite itemSprite;

    private InventoryManager inventoryManager;
 

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
    }

    //triggers AddItem() function and destroys the game object once it has been "picked up"
    public void PickUp()
    {
        if(inventoryManager == null)
        {
            inventoryManager=GameObject.Find("Inventory").GetComponent<InventoryManager>();
        }
        inventoryManager.AddItem(itemName, itemSprite);
        if(inventoryManager.pickedUp == true)
        {
            KillObject();
        }
    }

    //destroys the object
    void KillObject()
    {
        Destroy(gameObject);
        inventoryManager.pickedUp = false;
    }
}


