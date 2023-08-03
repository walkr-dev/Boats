using UnityEngine;
using UnityEngine.AI;

public class AIBoatBasic : Actor
{
    public int value = 5;

    public NavMeshAgent agent;

    public GameObject coinObject;

    private Vector3 destination;
    public override void Start()
    {
        ChooseNewLocation();
    }

	void ChooseNewLocation()
	{
        destination = transform.position + new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y) * Random.Range(20, 100);
        agent.destination = destination;
    }

    public override void Update()
    {
        if (agent.remainingDistance < 0.01)
		{
            ChooseNewLocation();
		}
    }

	public override void OnTakeDamage(){}

	public override void OnDeath()
	{
        DestroyBoat();
	}

	public void DestroyBoat()
	{
        CoinUtility.SpawnCoinsAroundArea(transform.position, value);
		for (int i = 0; i < value; i++)
		{
            var randomPosition = Random.insideUnitCircle * Random.Range(1,5);
            var pos = transform.position + new Vector3(randomPosition.x, 0, randomPosition.y);
            Instantiate(coinObject, pos, transform.rotation);
		}
        Destroy(gameObject);
	}
}
