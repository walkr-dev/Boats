using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleVisuals : MonoBehaviour
{
	public GameObject goldSmall;
	public GameObject goldMedium;
	public GameObject goldLarge;

	public enum GoldAmount
	{
		NONE,
		SMALL,
		MEDIUM,
		LARGE
	};

	public void SetGoldVisual(GoldAmount amount)
	{
		goldSmall.SetActive(false);
		goldMedium.SetActive(false);
		goldLarge.SetActive(false);
		switch (amount)
		{
			case GoldAmount.SMALL:
				goldSmall.SetActive(true);
				break;
			case GoldAmount.MEDIUM:
				goldMedium.SetActive(true);
				break;
			case GoldAmount.LARGE:
				goldLarge.SetActive(true);
				break;
			default:
				break;
		}
	}

}
