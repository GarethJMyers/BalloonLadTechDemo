using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonHeadBehav_BASIC : MonoBehaviour
{
	Rigidbody m_Rigidbody;
    Vector3 m_Movement;
	
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody> ();
    }
	
	void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
		m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();
        
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement);
    }
}
