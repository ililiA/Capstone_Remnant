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
	/*

	[Header("Audio")]
    
    public AudioSource aud;
    public AudioClip bossHurt;
    [Range(0f, 1f)]
    public float volume = .5f;
	*/

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
			//aud.PlayOneShot(bossHurt);
		}


		if (currentHealth <= 400)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (currentHealth <= 0)
		{
			Die();
			DeleteHealthBar();
		}
	}

	void DeleteHealthBar()
	{
		GetComponent<HealthBar>().DeleteHealth();
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		GetComponent<HealthBar>().Defeat();
	}

}
