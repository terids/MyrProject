using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modify the object's material to match that of the projectile
[CreateAssetMenu(fileName = "Colour Modifier", menuName = "SkillModifiers/ColourModifierSO")]
public class ColourModifier : ModifierBase
{
	public override void Apply(GameObject gob)
	{
		Renderer r = gob.GetComponentInChildren<Renderer>();

		if (r)
		{
			r.material.color = ProjectileColour;
		}
		else
		{
			Debug.Log("No Renderer Found");
		}
	}
}
