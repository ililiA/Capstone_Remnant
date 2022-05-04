using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
            Effects();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        //die anaimation
        //animator.SetBool("IsDead", true);

        //disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
        Destroy(this.gameObject);
        Destroy(transform.parent.gameObject);
    }

    void Effects()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}
