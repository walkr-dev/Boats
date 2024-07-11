using System;
using UnityEngine;

public class VehicleAudio : MonoBehaviour
{
    Rigidbody rb;

    public AudioSource engineAudio;

    void Start()
    {
        rb = transform.root.GetComponentInChildren<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
    {
        engineAudio.pitch = Mathf.Clamp(rb.linearVelocity.magnitude, 0, 2);
    }
}
