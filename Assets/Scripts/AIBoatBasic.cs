using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBoatBasic : Actor
{
    public int value = 5;
    public Vector2 rangeMinMax = new Vector2(10, 20);
    
    [Range(1, 10)]
    public float agentSpeed = 3.5f;
    private NavMeshAgent _agent;
    private Vector3 destination;

    public GameObject homePosition;

    public override void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = agentSpeed;

        ChooseNewLocation();
    }

	void ChooseNewLocation()
	{
        var homepoint = homePosition == null ? transform.position : homePosition.transform.position;

        destination = homepoint + new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y) * Random.Range(rangeMinMax.x, rangeMinMax.y);

        _agent.SetDestination(destination);
    }

    public override void Update()
    {
        if (_agent.remainingDistance < 0.01)
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
        Destroy(gameObject);
	}
}
