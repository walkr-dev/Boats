using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
	public override void OnDeath()
	{
		Debug.Log("Player ded.");
	}

	public override void Start() {}

	public override void Update() {}

}
