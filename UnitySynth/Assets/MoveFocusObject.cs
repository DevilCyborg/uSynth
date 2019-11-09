using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFocusObject : MonoBehaviour
{
	Rigidbody rb;
	public float speed = 10f;
	
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = false;
	}
	
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
		{
			rb.velocity = new Vector3(.5f, 0, 0) * speed;
		}
		
		if (Input.GetKey(KeyCode.A))
		{
			rb.velocity = new Vector3(-.5f, 0, 0) * speed;
		}
		
		if (Input.GetKey(KeyCode.W))
		{
			rb.velocity = new Vector3(0, 0, .5f) * speed;
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			rb.velocity = new Vector3(0, 0, -.5f) * speed;
		}
	}
}
