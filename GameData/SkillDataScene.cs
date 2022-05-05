using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataScene : MonoBehaviour
{
    [SerializeField] private List<PlayerSkill> playerSkills;
    [SerializeField] private List<SkillsData> skillsDatas;

    private void Awake()
    {
        for (int i=0; i<skillsDatas.Count; i++)
        {
            if (playerSkills[i] != null)
            {
                skillsDatas[i].playerSkill = playerSkills[i];
            }
        }
    }
}
