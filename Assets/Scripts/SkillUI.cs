using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillUI : MonoBehaviour
{
	public Color32 DefaultColour = Color.black;
	public Color32 SelectedColour = Color.red;
	public TextMeshProUGUI[] SkillTexts;

	public void SelectSkill(int skillIndex)
	{
		foreach (TextMeshProUGUI text in SkillTexts)
		{
			// Disable and enable the gameobject, otherwise TMPro doesn't update outline ¯\_(ツ)_/¯
			text.gameObject.SetActive(false);
			text.outlineColor = DefaultColour;
			text.gameObject.SetActive(true);
		}

		
		if (SkillTexts.Length > skillIndex)
		{
			SkillTexts[skillIndex].gameObject.SetActive(false);
			SkillTexts[skillIndex].outlineColor = SelectedColour;
			SkillTexts[skillIndex].gameObject.SetActive(true);
		}
	}
}
