using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoatWeapon : MonoBehaviour
{

    public GameObject target;
    public Transform turretTransform;
    public GameObject projectile;
    public float playerAcquireRange = 10;
    public float fireTimer = 0;
    public float delay = 1.25f;

    bool CanFire => Time.time >= fireTimer;

    void Update()
    {
        if (!target)
        {
            var players = GameObject.FindGameObjectsWithTag("Player");
			foreach (var player in players)
			{
                if (isPlayerWithinRange(player.transform))
				{
                    target = player;
                    break;
				}
			}
            return;
        }

        AimWeapon(target.transform.position);
        if (CanFire && isPlayerWithinRange(target.transform))
		{
            FireWeapon();
		}

    }

    bool isPlayerWithinRange(Transform player)
	{
        return Vector3.Distance(player.position, transform.position) <= playerAcquireRange;
	}

    void AimWeapon(Vector3 position)
	{
        turretTransform.LookAt(position);
	}


    void FireWeapon()
	{
        Instantiate(projectile, turretTransform.position + turretTransform.forward * 1.25f, turretTransform.rotation);
        fireTimer = Time.time + delay;
	}

}
