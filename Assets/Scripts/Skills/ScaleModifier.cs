using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scale Modifier", menuName = "SkillModifiers/ScaleModifierSO")]
public class ScaleModifier : ModifierBase
{
	public float ScaleValue = 0.0f;

	public override void Apply(GameObject gob)
	{
		gob.transform.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
	}
}
