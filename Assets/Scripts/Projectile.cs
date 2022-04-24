using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private ModifierBase Modifier = null;
	private float Lifetime = 0.0f;

	public void Launch(ModifierBase modifier, Vector3 launchDirection)
	{
		Modifier = modifier;

		// Change projectile colour based on currently active skill
		Renderer r = GetComponentInChildren<Renderer>();
		if (r)
		{
			r.material.color = modifier.ProjectileColour;
		}

		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb)
		{
			if (Modifier)
			{
				rb.AddForce(launchDirection * Modifier.ProjectileForce);
			}
		}
	}

	public void Update()
	{
		Lifetime += Time.deltaTime;

		if (Modifier && Lifetime > Modifier.ProjectileLifetime)
		{
			Destroy(gameObject);
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("NoSkillModify"))
		{
			return;
		}
		
		if (Modifier)
		{
			Modifier.Apply(collision.gameObject);
		}

		Destroy(gameObject);
	}
}
