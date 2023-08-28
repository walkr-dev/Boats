using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjective : MonoBehaviour
{

    Objective currentObjective;

	void SetObjective(Objective objective)
	{

	}

    // Start is called before the first frame update
    void Start()
    {
        if (currentObjective == null)
        {
            SetObjective(GetRandomObjective());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // objective text
        // objective direction / destination (if applicable)
    }

    public Objective GetRandomObjective()
	{
        DeliveryObjective deliveryObjective = new DeliveryObjective(5, Vector3.zero, Vector3.zero);

        int choice = Random.Range(0, 3);
		switch (choice)
		{
            case 0:
                return deliveryObjective;
            case 1:
                return deliveryObjective;
			default:
                return deliveryObjective;
		}
	}
}

public enum ObjectiveState {
    NONE,
    STARTED,
    INPROGRESS,
    COMPLETED,
    FAILED
}

abstract public class Objective
{
    public ObjectiveState state = ObjectiveState.NONE;

    public void Start()
	{
        state = ObjectiveState.STARTED;
        OnStarted();
	}

    public void Complete() {
        state = ObjectiveState.COMPLETED;
        OnComplete();
    }

    public abstract void OnComplete();
    public abstract void OnStarted();
    public abstract void UpdateState();
}

class DeliveryObjective : Objective
{
    bool hasPickedUp = false;

    public Vector3 pickupLoc;
    public Vector3 destLoc;

    public Vector3 objectiveLocation;
    public void PickUp() => hasPickedUp = true;

    public DeliveryObjective(int value, Vector3 pickupLocation, Vector3 destinationLocation)
	{
		pickupLoc = pickupLocation;
        destLoc = destinationLocation;

	}

	public override void OnStarted()
	{
        objectiveLocation = pickupLoc;
        state = ObjectiveState.INPROGRESS;
	}
	public override void OnComplete()
	{
        CoinUtility.SpawnCoinsAroundArea(destLoc, 10); // make it a dynamic value i guess
	}
	public override void UpdateState()
	{
		if (hasPickedUp)
		{
            objectiveLocation = destLoc;
		}
	}
}
