using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private UIController ui;

    public int health = 100, mana = 100;

    public float regenTimer = 1, manaRegenInterval = 1;

    //PlayerSaveAndLoad save;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetHealthSlider(health);
        ui.SetManaSlider(mana);

        //save = GetComponent<PlayerSaveAndLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mana < 100)
        {
            if(regenTimer > manaRegenInterval)
            {
                mana += 5;
                regenTimer = 0;
                ui.SetManaSlider(mana);
            }
            else
            {
                regenTimer += Time.deltaTime;
            }
        }
    }
    
    public void TakeDamage(int damage)
	{
		//health -= damage;
        ChangeHealth(-damage);
        Debug.Log("ouch");

		//StartCoroutine(DamageAnimation());

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
        //Destroy(this.gameObject);
        ChangeHealth(+200);
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:5);
	}

    public void ChangeHealth(int byAmount)
    {
        health += byAmount;

        if(health <= 0)
        {
            // replace this with something better later
            //Application.LoadLevel(0);

            //call the loadHealth function
            //save.Load();
        }

        if(health > 100)
        {
            health = 100;
        }

        ui.SetHealthSlider(health);
    }

    public void ChangeMana(int byAmount)
    {
        mana += byAmount;
        
        if(mana > 100)
        {
            mana = 100;
        }

        ui.SetManaSlider(mana);
    }

    
}