using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
	public GameObject playerBoatPrefab;
	public GameObject currentPlayer;
	public Transform spawnPosition;

	PlayerInventory inventory;

	public override void OnDeath()
	{
		//TODO: get rid of hacky transform child stuff, yuck
		var deathLocation = currentPlayer.transform.GetChild(0).position;
		if (inventory.Gold > 0)
		{
			var goldLost = Mathf.Max(1, inventory.Gold / 3);
			CoinUtility.SpawnCoinsAroundArea(deathLocation, goldLost);
			inventory.RemoveGold(goldLost);
		}
		Destroy(currentPlayer);
		StartCoroutine(RespawnPlayerAfterDelay(3));
	}

	IEnumerator RespawnPlayerAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		RespawnPlayer();
	}

	void RespawnPlayer()
	{
		SetPlayerObject(Instantiate(playerBoatPrefab, spawnPosition.position, spawnPosition.rotation, gameObject.transform));
	}

	public override void OnTakeDamage(){}

	public override void Start() {
		inventory = GetComponent<PlayerInventory>();
		RespawnPlayer();
	}


	void SetPlayerObject(GameObject player)
	{
		currentPlayer = player;
		inventory.player = player;
		inventory.OnPlayerRespawn();
	}
	public override void Update() {}
}
