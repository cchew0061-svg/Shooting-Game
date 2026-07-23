using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public string selectedWeapon = "gun1";
    public Gun1 gun1;
    public Gun2 gun2;
    public Knife knife;

    private InventoryManager inventoryManager;
    private InputManager inputManager;

    void Start()
    { 
		inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
		inputManager = GameObject.Find("player").GetComponent<InputManager>();
    }

    //ammunition used if right click input is detected depending on the currently held gun and ammunition is in inventory
    void Update()
    {
		inputManager = GameObject.Find("player").GetComponent<InputManager>();
		if(inputManager.onFoot.Reload.triggered)
		{
			if(selectedWeapon == "gun1")
			{
				if(gun1.ammunition != gun1.maxAmmunition)
				{
					inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
					inventoryManager.UseItem("Green Ammunition");
				}
			}

			if(selectedWeapon == "gun2")
			{
				if(gun2.ammunition != gun2.maxAmmunition)
				{
					inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
					inventoryManager.UseItem("Blue Ammunition");
				}
			}
		}
    }

    //when left mouse button is pressed, calls functions from other scripts depending on the currently selected weapon
    public void Shoot()
    {
		if(selectedWeapon == "gun1")
		{
			gun1.ShootGun1();	
		}
		if(selectedWeapon == "gun2")
		{
			gun2.ShootGun2();	
		}
		if(selectedWeapon == "knife")
		{
			knife.Attack();	
		}
    }

    //swaps to gun1 by disabling all weapons and then enabling gun1
    public void SwapGun1()
    {
		Disable();
		gun1.gameObject.SetActive(true);
		selectedWeapon = "gun1";
    }

    //swaps to gun2 by disabling all weapons and then enabling gun2
    public void SwapGun2()
    {
		Disable();
		gun2.gameObject.SetActive(true);
		selectedWeapon = "gun2";
    }

    //swaps to knife by disabling all weapons and then enabling knife
    public void SwapKnife()
    {
		Disable();
		knife.gameObject.SetActive(true);
		selectedWeapon = "knife";
    }

    //disables all weapons and clears the selected weapon
    public void Disable()
    {
		selectedWeapon = null;
		gun1.gameObject.SetActive(false);
		gun2.gameObject.SetActive(false);
		knife.gameObject.SetActive(false);
    }

    //reloads the currently held gun
    public void Reload()
    {
		if(selectedWeapon == "gun1")
		{
			gun1.ReloadGun1();
		}
		if(selectedWeapon == "gun2")
		{
			gun2.ReloadGun2();
		}
    }
}

