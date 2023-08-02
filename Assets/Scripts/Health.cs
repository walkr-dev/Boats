using UnityEngine;

public class Health : MonoBehaviour
{
	public int health = 3;

	public Actor actor;
	
	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health < 0) actor.OnDeath();
	}

}
