using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	private int gold = 0;
	private int mediumThreshold = 10;
	private int largeThreshold = 20;

	public GameObject player;

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
		CheckGoldThresholds();
	}

	public void RemoveGold(int amount)
	{
		if (amount < 1)
		{
			Debug.LogError("Cannot remove negative gold!", gameObject);
			return;
		}
		if (gold - amount >= 0) gold -= amount;
		CheckGoldThresholds();
	}

	void CheckGoldThresholds()
	{
		if (Gold < 1)
		{
			player.GetComponentInChildren<VehicleVisuals>().SetGoldVisual(VehicleVisuals.GoldAmount.NONE);
			return;
		}
		if (Gold >= 1 && Gold < mediumThreshold)
		{
			player.GetComponentInChildren<VehicleVisuals>().SetGoldVisual(VehicleVisuals.GoldAmount.SMALL);
			return;
		}
		if (Gold >= mediumThreshold && Gold < largeThreshold)
		{
			player.GetComponentInChildren<VehicleVisuals>().SetGoldVisual(VehicleVisuals.GoldAmount.MEDIUM);
			return;
		}
		player.GetComponentInChildren<VehicleVisuals>().SetGoldVisual(VehicleVisuals.GoldAmount.LARGE);
	}
}
