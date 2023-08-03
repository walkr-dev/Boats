using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private int gold = 0;
	public int Gold { 
		get
		{
			return gold;
		} 
	}
    public void AddGold(int amount)
	{
		if (amount < 1)
		{
			Debug.LogError("Cannot add negative gold!", gameObject);
			return;
		}
		gold += amount;
	}

	public void RemoveGold(int amount)
	{
		if (amount < 1)
		{
			Debug.LogError("Cannot remove negative gold!", gameObject);
			return;
		}
		if (gold - amount >= 0) gold -= amount;
	}
}
