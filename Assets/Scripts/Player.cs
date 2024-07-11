using Assets.Scripts;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Actor
{
	public GameObject playerBoatPrefab;
	public GameObject currentPlayer;
	public Transform spawnPosition;
	public Vehicle playerVehicle;
	public VehicleWeapon weapon;
	
	RegeneratingHealth health;
	public PlayerInventory inventory;

	PlayerLivesVisual livesVisual;

	// powerups
	public bool isBoosting = false;
	public bool canBoost = false;

	const int MAX_LIVES = 3;
	public int lives = MAX_LIVES;

	public int bossKills = 0;
	public GameObject endGameCanvas;
	private TextMeshProUGUI coinText;
	private TextMeshProUGUI bossText;

	public override void Start()
	{
		inventory = GetComponent<PlayerInventory>();
		health = GetComponent<RegeneratingHealth>();
		spawnPosition = GameObject.FindWithTag("SpawnPoint").transform;
		livesVisual = GameObject.FindWithTag("UI").GetComponentInChildren<PlayerLivesVisual>();
		livesVisual.OnLifeStateChanged(lives);
		endGameCanvas.SetActive(false);
		coinText = endGameCanvas.transform.Find("CoinText").GetComponent<TextMeshProUGUI>();
		bossText = endGameCanvas.transform.Find("BossText").GetComponent<TextMeshProUGUI>();
		RespawnPlayer();
	}

	public void AddLife()
	{
		lives++;
		if (lives > MAX_LIVES)
		{
			lives = MAX_LIVES;
			return;
		}
		livesVisual.OnLifeStateChanged(lives);
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
		livesVisual.OnLifeStateChanged(lives);
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

	void SetPlayerObject(GameObject player)
	{
		currentPlayer = player;
		inventory.player = player;
		inventory.OnPlayerRespawn();
		playerVehicle = player.GetComponentInChildren<Vehicle>();
		weapon = player.GetComponentInChildren<VehicleWeapon>();
		player.GetComponentInChildren<PlayerHealthVisuals>().playerHealth = health;
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

	public void AVENGERSENDGAME(){
		endGameCanvas.SetActive(true);
		coinText.text = $"you collected {inventory.Gold} coins! nice";
		bossText.text = $"you bonked {bossKills} bosses! yippee";
	}
	public void ReturnToMenu(){
		SceneManager.LoadScene("MainMenu");
	}
}
