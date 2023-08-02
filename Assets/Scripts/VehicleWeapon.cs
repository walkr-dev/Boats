using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWeapon : MonoBehaviour
{

    public KeyCode fireWeapon;
    public GameObject projectile;
    public Transform firePosition;

    void Update()
    {
        // TODO: automatic weapons...
        if (Input.GetKeyDown(fireWeapon))
		{
            HandleWeaponFire();
		}
    }

    void HandleWeaponFire()
	{
        Instantiate(projectile, firePosition.position, firePosition.rotation);
	}

}
