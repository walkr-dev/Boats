using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public GameObject pickupEffect;
	private void OnTriggerEnter(Collider other)
	{
        var root = other.transform.root;
        if (root.TryGetComponent<PlayerInventory>(out var playerInventory))
		{
			playerInventory.AddGold(1);
			Instantiate(pickupEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}

public static class CoinUtility
{
	public static void SpawnCoinsAroundArea(Vector3 position, int amount)
	{
		var coinObject = Resources.Load("Prefabs/Coin");
		for (int i = 0; i < amount; i++)
		{
			var randomPosition = Random.insideUnitCircle * Random.Range(1, 5);
			var pos = position + new Vector3(randomPosition.x, 0, randomPosition.y);
			Object.Instantiate(coinObject, pos, Quaternion.identity);
		}
	}

}
