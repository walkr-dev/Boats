using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWeapon : MonoBehaviour
{

    public KeyCode fireWeapon;
    public GameObject projectile;
    public Transform firePosition;

    public float fireRate = 0.25f;
    public float fireTimer = 0;

    public int weaponStage = 0;
    const int MAX_WEAPON_STAGE = 4;
    public List<GameObject> stageVisuals = new List<GameObject>();

    bool canFire => Time.time >= fireTimer;

    void Update()
    {
        // TODO: automatic weapons...
        if (Input.GetKey(fireWeapon))
		{
            HandleWeaponFire();
		}
    }
    
    public void UpgradeWeaponStage()
    {

    }

    void HandleWeaponFire()
	{
        if (canFire)
		{
            Instantiate(projectile, firePosition.position, firePosition.rotation);
            fireTimer = Time.time + fireRate;
		}
	}

}
