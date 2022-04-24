using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float MoveSpeed = 5.0f;
	public float HorizontalRotateSpeed = 2.0f;
	public float VerticalRotateSpeed = 2.0f;
	
	void Start()
	{
		
	}

	void Update()
	{
		// -- Movement
		float verticalInput = Input.GetAxis("Vertical");
		float horizontalInput = Input.GetAxis("Horizontal");

		// We rotate with mouse, so eliminate y axis to avoid moving into the sky
		Vector3 forwardVector = transform.forward;
		forwardVector.y = 0.0f;
		forwardVector *= (verticalInput * MoveSpeed * Time.deltaTime);

		// We rotate with mouse, so eliminate y axis to avoid moving into the sky
		Vector3 rightVector = transform.right;
		rightVector.y = 0.0f;
		rightVector *= (horizontalInput * MoveSpeed * Time.deltaTime);

		transform.position += forwardVector + rightVector;


		// -- Rotation
		float mouseXInput = Input.GetAxis("Mouse X");
		float mouseYInput = Input.GetAxis("Mouse Y");

		float yaw = HorizontalRotateSpeed * mouseXInput;
		float pitch = VerticalRotateSpeed * mouseYInput;

		transform.Rotate(0.0f, yaw, 0.0f, Space.World);
		transform.Rotate(-pitch, 0.0f, 0.0f, Space.Self);
	}
}
