using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Transform playerTransform;
    public TextMeshPro objectiveText;

	private void Start()
	{
		ShowObjective();
	}

	void Update()
    {
        transform.position = playerTransform.position;
        
        if (Input.GetKeyDown(KeyCode.O))
		{
            ShowObjective();
		}
    }

    void ShowObjective()
	{
        objectiveText.enabled = true;
        objectiveText.text = GetCurrentObjective();
        StartCoroutine(HideObjective(2));
	}

	private string GetCurrentObjective()
	{
        return "Eliminate Boats\n 0/2";
	}

	IEnumerator HideObjective(float seconds)
	{
        yield return new WaitForSeconds(seconds);
        objectiveText.enabled = false;
	}
}
