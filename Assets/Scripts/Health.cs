using UnityEngine;

public class Health : MonoBehaviour
{
	public int maxHealth = 3;
	public int health = 3;

	public Actor actor;
	
	public void TakeDamage(int damage)
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
