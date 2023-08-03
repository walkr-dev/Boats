using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
	public GameObject playerBoatPrefab;
	public GameObject currentPlayer;
	public Transform spawnPosition;

	public override void OnDeath()
	{
		Destroy(currentPlayer);
		// drop % of coins?
		RespawnPlayer();
	}

	private void RespawnPlayer()
	{
		currentPlayer = Instantiate(playerBoatPrefab, spawnPosition.position, spawnPosition.rotation,gameObject.transform);
	}

	public override void OnTakeDamage(){}

	public override void Start() {
		RespawnPlayer();
	}

	public override void Update() {}
}
