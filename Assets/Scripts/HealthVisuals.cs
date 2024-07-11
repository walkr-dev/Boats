using UnityEngine;

public class HealthVisuals : MonoBehaviour
{
    public float mediumHealthThreshold = 2.8f;
    public float lowHealthThreshold = 1.8f;

    public Health health;

	public GameObject lowHealthThresholdVisual;
	public GameObject mediumHealthThresholdVisual;

	private void Update()
	{
		if ( health.health < lowHealthThreshold )
		{
			lowHealthThresholdVisual.SetActive(true);
			return;
		}
		
		if ( health.health < mediumHealthThreshold )
		{
			lowHealthThresholdVisual.SetActive(true);
			return;
		}


		else
		{
			lowHealthThresholdVisual.SetActive(false);
			mediumHealthThresholdVisual.SetActive(false);
		}
	}
}
