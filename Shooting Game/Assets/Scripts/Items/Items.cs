using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Items : ScriptableObject
{
    public string itemName;

    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    //uses item to heal the player if item is set for healing purposes or reload ammunition
    public void UseItem()
    {
		if(statToChange == StatToChange.health)
		{
			GameObject.Find("player").GetComponent<PlayerHealth>().RestoreHealth(amountToChangeStat);
		}

		if(statToChange == StatToChange.greenammunition)
		{
			GameObject.Find("Weapons").GetComponent<Weapons>().Reload();
		}

		if(statToChange == StatToChange.blueammunition)
		{
			GameObject.Find("Weapons").GetComponent<Weapons>().Reload();
		}
    }

    //list of stats that can be changed
    public enum StatToChange
    {
		blueammunition,
		greenammunition,
		health
    };
}
