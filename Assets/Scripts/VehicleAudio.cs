using System;
using UnityEngine;

public class VehicleAudio : MonoBehaviour
{
    float topSpeed = 45;
    float currentSpeed = 0;
    float pitch = 0;

    Rigidbody rb;
    public AudioSource engineAudio;

    void Start()
    {
        rb = transform.root.GetComponentInChildren<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
    {
        currentSpeed = rb.linearVelocity.magnitude * 3.6f;
        pitch = currentSpeed / topSpeed;
        engineAudio.pitch = pitch;
    }
}
