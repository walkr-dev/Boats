using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public GameObject pickupEffect;
	private void OnTriggerEnter(Collider other)
	{
        var root = other.transform.root;
        if (root.CompareTag("Player"))
		{
            root.GetComponent<PlayerInventory>().AddGold(1);
			Instantiate(pickupEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
