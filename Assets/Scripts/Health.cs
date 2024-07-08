using UnityEngine;

public class Health : MonoBehaviour
{
	public float maxHealth = 3;
	public float health = 3;

	public Actor actor;
	
	public virtual void TakeDamage(float damage)
	{
		health -= damage;
		actor.OnTakeDamage();
		if (health < 0)
		{
			actor.OnDeath();
			health = maxHealth;
		}
	}

}
