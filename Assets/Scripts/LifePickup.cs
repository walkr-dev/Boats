using UnityEngine;

public class LifePickup : MonoBehaviour
{
	public GameObject pickupEffect;

	private void OnTriggerEnter(Collider other)
	{
		var root = other.transform.root;
		if (root.TryGetComponent<Player>(out var player))
		{
			player.AddLife();
			Instantiate(pickupEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
