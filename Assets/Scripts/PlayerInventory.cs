using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private int gold = 0;
    public void AddGold(int amount)
	{
		if (amount < 1)
		{
			Debug.LogError("Cannot give negative gold!", gameObject);
			return;
		}
		gold += amount;
	}
}
