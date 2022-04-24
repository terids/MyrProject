using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Modifier", menuName = "SkillModifiers/DefaultModifierSO")]
public class ModifierBase : ScriptableObject
{
	public Color ProjectileColour = Color.white;
	public float ProjectileLifetime = 5.0f;
	public float ProjectileForce = 50.0f;

	public virtual void Apply(GameObject gob)
	{
		// Default skill will do nothing
	}
}
