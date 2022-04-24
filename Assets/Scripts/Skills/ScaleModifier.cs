using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scale an objects transform
[CreateAssetMenu(fileName = "Scale Modifier", menuName = "SkillModifiers/ScaleModifierSO")]
public class ScaleModifier : ModifierBase
{
	public float ScaleValue = 0.0f;

	public override void Apply(GameObject gob)
	{
		// We don't want to fall through the floor, so scale up from the bottom

		Transform t = gob.transform.root; // Make sure to only modify the root object
		
		Vector3 currentPos = t.position;
		float distToGround = currentPos.y;
		Vector3 groundPos = currentPos;
		groundPos.y = 0.0f;
 
		float relativeScale = ScaleValue / t.localScale.x;
 
		// Move the object above floor relative to scale
		Vector3 finalPosition = groundPos + Vector3.up * distToGround * relativeScale;

		t.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
		t.position = finalPosition;
	}
}
