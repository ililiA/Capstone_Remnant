using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

	public int maxHealth = 500;
	public int currentHealth;

	public GameObject deathEffect;

	public bool isInvulnerable = false;
	HealthBar bar;

	void Start()
    {
        currentHealth = maxHealth;
    }

	public void TakeDamage(int damage)
	{
		Debug.Log("Hit Boss");
		if (isInvulnerable)
		{
			return;
		}
		else
		{
			currentHealth -= damage;
		}


		if (currentHealth <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
		bar.GetComponent<HealthBar>().Defeat();
	}

}
