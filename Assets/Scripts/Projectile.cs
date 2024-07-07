using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float initialForce = 5000;
	public GameObject explosionEffect;
	public bool selfDestruct;
	public float selfDestructTime = 5;

	private void Awake()
	{
		var rb = GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * initialForce);
		if (selfDestruct)
		{
			StartCoroutine(SelfDestruct());
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		Health actorHealth;
		if (!collision.gameObject.transform.CompareTag("Player") && collision.gameObject.transform.root.TryGetComponent(out actorHealth))
		{
			actorHealth.TakeDamage(1);
		}
		OnProjectileDestroy();
	}

	void OnProjectileDestroy()
	{
		Instantiate(explosionEffect, transform.position, transform.rotation);
		Destroy(gameObject);
		StopCoroutine(SelfDestruct());
	}

	IEnumerator SelfDestruct()
	{
		yield return new WaitForSeconds(5);
		OnProjectileDestroy();
	}
}
