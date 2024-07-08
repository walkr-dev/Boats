using UnityEngine;

public class PlayerHealthVisuals : MonoBehaviour
{
    public float mediumHealthThreshold = 2.8f;
    public float lowHealthThreshold = 1.8f;

    [HideInInspector] public RegeneratingHealth playerHealth;

	public GameObject lowHealthThresholdVisual;
	public GameObject mediumHealthThresholdVisual;

	private void Update()
	{
		if ( playerHealth.health < lowHealthThreshold )
		{
			lowHealthThresholdVisual.SetActive(true);
		}
		
		if ( playerHealth.health < mediumHealthThreshold )
		{
			lowHealthThresholdVisual.SetActive(true);
		}

		else
		{
			lowHealthThresholdVisual.SetActive(false);
			mediumHealthThresholdVisual.SetActive(false);
		}
	}
}
