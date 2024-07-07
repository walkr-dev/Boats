using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
	public GameObject playerBoatPrefab;
	public GameObject currentPlayer;
	public Transform spawnPosition;
	public Vehicle playerVehicle;
	public VehicleWeapon weapon;

	PlayerInventory inventory;

	// powerups
	public bool isBoosting = false;
	public bool canBoost = false;

	const int MAX_LIVES = 3;
	public int lives = MAX_LIVES;

	public void AddLife()
	{
		lives++;
		if (lives > MAX_LIVES) lives = MAX_LIVES;
	}

	public override void OnDeath()
	{
		//TODO: get rid of hacky transform child stuff, yuck
		DropCoins();
		Destroy(currentPlayer);
		lives--;
		if (lives < 0)
		{
			//dead dead
			return;
		}
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
		playerVehicle = player.GetComponentInChildren<Vehicle>();
		weapon = player.GetComponentInChildren<VehicleWeapon>();
	}
	public override void Update() {}

	private void DropCoins()
	{
		var deathLocation = currentPlayer.transform.GetChild(0).position;
		if (inventory.Gold > 0)
		{
			var goldLost = Mathf.Max(1, inventory.Gold / 3);
			CoinUtility.SpawnCoinsAroundArea(deathLocation, goldLost);
			inventory.RemoveGold(goldLost);
		}
	}
}
