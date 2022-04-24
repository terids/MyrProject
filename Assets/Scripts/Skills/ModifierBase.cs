using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifierBase : ScriptableObject
{
	public Color ProjectileColour = Color.magenta;
	public float ProjectileLifetime = 5.0f;
	public float ProjectileForce = 50.0f;

	public abstract void Apply(GameObject gob);
}
