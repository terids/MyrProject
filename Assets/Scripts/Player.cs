using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float MoveSpeed = 5.0f;
	
	void Start()
	{
		
	}

	void Update()
	{
		float verticalInput = Input.GetAxis("Vertical");
		float horizontalInput = Input.GetAxis("Horizontal");

		transform.position += transform.forward * (verticalInput * MoveSpeed * Time.deltaTime);
		transform.position += transform.right * (horizontalInput * MoveSpeed * Time.deltaTime);
		
		
	}
}
