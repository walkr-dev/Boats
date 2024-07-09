using UnityEngine;

public class WeaponUpgradePickup : MonoBehaviour
{
	public GameObject pickupEffect;
	private void OnTriggerEnter(Collider other)
	{
		var root = other.transform.root;
		if (root.TryGetComponent<Player>(out var player))
		{
			player.weapon.UpgradeWeaponStage();
			Instantiate(pickupEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
