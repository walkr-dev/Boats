using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public GameObject upgradeVisual;


	public float fireRate = 0.25f;
    public float fireTimer = 0;

    public int weaponStage = 0;
    const int MAX_WEAPON_STAGE = 4;
    public List<GameObject> stageVisuals = new List<GameObject>();

    bool canFire => Time.time >= fireTimer;

    Rigidbody rb;
    public AudioSource fireAudioSource;
    public AudioSource upgradeAudioSource;


	private void Awake()
	{
        rb = transform.root.GetComponentInChildren<Rigidbody>();
	}

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

        upgradeAudioSource.Play();

        foreach (GameObject go in stageVisuals)
        {
            go.SetActive(false);
        }

        Instantiate(upgradeVisual, transform.position, transform.rotation);
        stageVisuals[weaponStage].SetActive(true);
    }


    void HandleWeaponFire()
	{
        var force = Mathf.Abs(rb.linearVelocity.magnitude) + 1700;
        var isUpgraded = weaponStage > 0;

        if (canFire)
		{
            switch (weaponStage)
            {
                case 0:
					SpawnCannonBallWithForce(force, isUpgraded, firePosition1.position, firePosition1.rotation);
                    break;
                case 1:
					SpawnCannonBallWithForce(force, isUpgraded, firePosition2.position, firePosition2.rotation);
					break;
				case 2:
					SpawnCannonBallWithForce(force, isUpgraded, firePosition3.position, firePosition3.rotation);
					SpawnCannonBallWithForce(force, isUpgraded, firePosition4.position, firePosition4.rotation);
					break;
				case 3:
					SpawnCannonBallWithForce(force, isUpgraded, firePosition3.position, firePosition3.rotation);
					SpawnCannonBallWithForce(force, isUpgraded, firePosition4.position, firePosition4.rotation);
					SpawnCannonBallWithForce(force, isUpgraded, firePosition5.position, firePosition5.rotation);
					SpawnCannonBallWithForce(force, isUpgraded, firePosition6.position, firePosition6.rotation);
					break;
				case 4:
					SpawnCannonBallWithForce(force, isUpgraded, firePosition3.position, firePosition3.rotation);
					SpawnCannonBallWithForce(force, isUpgraded, firePosition4.position, firePosition4.rotation);
					SpawnCannonBallWithForce(force, isUpgraded, firePosition5.position, firePosition5.rotation);
					SpawnCannonBallWithForce(force, isUpgraded, firePosition6.position, firePosition6.rotation);
					break;
				default:
                    break;
            }

            fireTimer = Time.time + fireRate;
		}
	}

    void SpawnCannonBallWithForce(float force, bool isUpgraded, Vector3 position, Quaternion rotation)
    {
        var cannonball = Instantiate(isUpgraded ? upgradedProjectile : projectile, position, rotation);
        cannonball.GetComponent<Projectile>().AddForce(force);
        fireAudioSource.Play();
    }

}
