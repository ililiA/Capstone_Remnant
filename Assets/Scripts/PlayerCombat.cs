using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask bossLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //play attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayers);

        //apply damage to enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        foreach(Collider2D boss in hitBoss)
        {
            Debug.Log("We hit " + boss.name);

            boss.GetComponent<BossHealth>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
