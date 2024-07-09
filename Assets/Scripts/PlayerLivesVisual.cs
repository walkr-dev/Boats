using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class PlayerLivesVisual : MonoBehaviour
	{
		public List<GameObject> lifeVisuals = new List<GameObject>();
		public GameObject lifeAddedParticle;
		public GameObject lifeRemovedParticle;
		public int previousLives = 3;

		public void OnLifeStateChanged(int lives)
		{
			if (lives > previousLives)
			{
				var index = lives - 1;
				lifeVisuals[index].SetActive(true);
				Instantiate(lifeAddedParticle, lifeVisuals[index].transform.position, lifeVisuals[index].transform.rotation);
			}
			if (lives < previousLives)
			{
				lifeVisuals[lives].SetActive(false);
				Instantiate(lifeRemovedParticle, lifeVisuals[lives].transform.position, lifeVisuals[lives].transform.rotation);

			}
			previousLives = lives;
		}
	}
}