using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Changes the scale of the balloon based on inflation.

public class HeadInflateBehaviour : MonoBehaviour
{
	Vector3 m_scaleChange;
	Vector3 m_newVec;
	private BLInflateBehaviour inflationScript;
	float inflationAmount;
	
	// public vars/objects
	public GameObject inflatingObject; // should be the parent object but not specifying parent in case that changes
	public float scaleRate = 1.0f;
	public float scaleOffset = 0.5f;
	public float minScale = 0.05f;
	public float maxScale = 5.0f;
	
	void Awake() {
		inflationScript = inflatingObject.GetComponent<BLInflateBehaviour>();
	}
    
    void FixedUpdate() {
		inflationAmount = inflationScript.GetInflation();
		
		//Debug.Log("Inflation amount: " + inflationAmount);
		transform.localScale = NewScale();
	}
	
	Vector3 NewScale() {
		float newScale = scaleOffset + (scaleRate * inflationAmount);
		if (newScale < minScale) {
			newScale = minScale;
		}
		if (newScale > maxScale) {
			newScale = maxScale;
		}
		
		m_newVec.Set(newScale, newScale, newScale);
		return m_newVec;
	}
}
