using UnityEngine;

public class RegeneratingHealth : Health
{
    public float regenTimer = 0;
    public float regenDelay = 1;
    public float regenFactor = 1;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        regenTimer = Time.time + regenDelay; 
    }

	bool canHeal => Time.time >= regenTimer;

    void Update()
    {
        if (health < maxHealth && canHeal)
        {
            health = Mathf.Clamp(health + (regenFactor * Time.deltaTime), 0, maxHealth);
        }
    }
}
