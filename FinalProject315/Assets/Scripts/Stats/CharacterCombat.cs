using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour 
{
    public float attackSpeed = 1f;
    public float attackCooldown = 0f;

    CharacterStats myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();    
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;    
    }

    public void Attack (CharacterStats targetStats)
    { 
        if(attackCooldown <= 0f)
        {
            Debug.Log("in attack");
            targetStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
        }
        
    }
}
