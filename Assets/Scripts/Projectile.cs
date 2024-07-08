using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float initialForce = 5000;
	public GameObject explosionEffect;
	public bool selfDestruct;
	public float selfDestructTime = 5;
	public float radius = 1;
	public LayerMask hitLayerMask;

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
		OnProjectileDestroy();
	}

	void OnProjectileDestroy()
	{
		var affectedList = Physics.OverlapSphere(transform.position, radius, hitLayerMask);

		foreach (var affected in affectedList)
		{
			if (affected.gameObject.transform.root.TryGetComponent<Health>(out var actorHealth))
			{
				actorHealth.TakeDamage(1);
			}
		}

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
