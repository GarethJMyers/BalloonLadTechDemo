using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows vertical control of Balloon Lad 

public class BLInflateBehaviour : MonoBehaviour
{
	Rigidbody m_Rigidbody;
	Vector3 m_Movement;
	
    // public objects/vars
	public float startInflation = 0.0f;
	public float minInflation = -1.0f;
	public float maxInflation = 5.0f;
	public float inflationRate = 1f;
	public float gravityAcc = 9.81f;
	public float movementRate = 1.0f;
	
	// private objects/vars
	private float inflationAmount;
	private float inputInflation;
	
	void Start() {
		m_Rigidbody = GetComponent<Rigidbody> ();
		inflationAmount = startInflation;
	}
	
	void Update() {
		// change inflation amount based on horizontal (left/right arrows) input
		inputInflation = Input.GetAxis ("Horizontal");
		ChangeInflation();
	}
	
	void FixedUpdate() {
		Debug.Log("Inflation amount: " + inflationAmount);
		
		m_Movement.Set(0f, inflationAmount * movementRate, 0f);
		m_Movement.Normalize();
		m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement);
	}
	
	private void ChangeInflation() {
		// change inflation based on input, make sure stays within max/min
		if (
			(inputInflation < 0 && inflationAmount > minInflation) || 
			(inputInflation > 0 && inflationAmount < maxInflation)
		) {
			inflationAmount = inflationAmount + (inputInflation * inflationRate);
		}
		if (inflationAmount < minInflation) {
			inflationAmount = minInflation;
		}
		if (inflationAmount > maxInflation) {
			inflationAmount = maxInflation;
		}
	}
}
