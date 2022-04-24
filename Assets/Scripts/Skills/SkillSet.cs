using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill Set", menuName = "SkillModifiers/SkillSetSO")]
public class SkillSet : ScriptableObject
{
	public ModifierBase[] Skills;
}
