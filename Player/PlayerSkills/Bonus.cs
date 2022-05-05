using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public SkillsData skillsData;
    [SerializeField] private LayerMask layer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layer.value & (1 << collision.gameObject.layer)) != 0)
        {
            skillsData.playerSkill.AddSkill(0);
            Destroy(gameObject);
        }
        
    }
}
