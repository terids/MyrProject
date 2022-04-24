using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
	[Header("Movement")]
	public float MoveSpeed = 5.0f;
	public float HorizontalRotateSpeed = 2.0f;
	public float VerticalRotateSpeed = 2.0f;

	[Header("Weapon")]
	public Transform BarrelTransform = null;
	public GameObject ProjectilePrefab = null;
	public SkillSet CurrentSkillSet = null;

	private int CurrentSkillIndex = 0;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
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


		// -- Skill selection
		if (Input.inputString != "")
		{
			int num;
			bool isNumber = Int32.TryParse(Input.inputString, out num);

			if (isNumber && num >= 0 && num < 10)
			{
				CurrentSkillIndex = num;
			}
		}


		// -- Fire weapon
		if (Input.GetMouseButtonDown(0))
		{
			if (ProjectilePrefab)
			{
				GameObject projectileGob = Instantiate(ProjectilePrefab, BarrelTransform.position, Quaternion.identity);
				Projectile projectile = projectileGob.GetComponent<Projectile>();

				bool skillAvailable = CurrentSkillSet && CurrentSkillSet.Skills.Length > CurrentSkillIndex;

				if (projectile && skillAvailable)
				{
					projectile.Launch(CurrentSkillSet.Skills[CurrentSkillIndex], transform.forward);
				}
			}
		}
	}
}
