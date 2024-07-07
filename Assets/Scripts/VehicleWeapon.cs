using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWeapon : MonoBehaviour
{

    public KeyCode fireWeapon;

    public GameObject projectile;
    public GameObject upgradedProjectile;

    public Transform firePosition1;
	public Transform firePosition2;
	public Transform firePosition3;
	public Transform firePosition4;
	public Transform firePosition5;
	public Transform firePosition6;


	public float fireRate = 0.25f;
    public float fireTimer = 0;

    public int weaponStage = 0;
    const int MAX_WEAPON_STAGE = 4;
    public List<GameObject> stageVisuals = new List<GameObject>();

    bool canFire => Time.time >= fireTimer;

    void Update()
    {
        if (Input.GetKey(fireWeapon))
		{
            HandleWeaponFire();
		}
    }
    
    public void UpgradeWeaponStage()
    {
        if (weaponStage == MAX_WEAPON_STAGE) return;

        weaponStage++;

        foreach (GameObject go in stageVisuals)
        {
            go.SetActive(false);
        }

        stageVisuals[weaponStage].SetActive(true);
    }

    void HandleWeaponFire()
	{
        var projectileToFire = weaponStage > 0 ? upgradedProjectile : projectile;

        if (canFire)
		{
            switch (weaponStage)
            {
                case 0:
					Instantiate(projectileToFire, firePosition1.position, firePosition1.rotation);
                    break;
                case 1:
					Instantiate(projectileToFire, firePosition2.position, firePosition2.rotation);
					break;
				case 2:
					Instantiate(projectileToFire, firePosition3.position, firePosition3.rotation);
					Instantiate(projectileToFire, firePosition4.position, firePosition4.rotation);
					break;
				case 3:
					Instantiate(projectileToFire, firePosition3.position, firePosition3.rotation);
					Instantiate(projectileToFire, firePosition4.position, firePosition4.rotation);
					Instantiate(projectileToFire, firePosition5.position, firePosition5.rotation);
					Instantiate(projectileToFire, firePosition6.position, firePosition6.rotation);
					break;
				case 4:
					Instantiate(projectileToFire, firePosition3.position, firePosition3.rotation);
					Instantiate(projectileToFire, firePosition4.position, firePosition4.rotation);
					Instantiate(projectileToFire, firePosition5.position, firePosition5.rotation);
					Instantiate(projectileToFire, firePosition6.position, firePosition6.rotation);
					break;
				default:
                    break;
            }

            fireTimer = Time.time + fireRate;
		}
	}

}
