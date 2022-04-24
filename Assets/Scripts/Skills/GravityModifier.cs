using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gravity Modifier", menuName = "SkillModifiers/GravityModifierSO")]
public class GravityModifier : ModifierBase
{
	public bool GravityValue = true;

	public override void Apply(GameObject gob)
	{
		Transform t = gob.transform.root;

		Rigidbody rb = t.GetComponent<Rigidbody>();

		if (rb)
		{
			rb.useGravity = GravityValue;
		}
	}
}
