using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public BossHealth bossHealth;
	public Slider slider;
    //public GameObject trigger;

    //slider.SetActive(true);

    void Awake()
    {
        if(slider == null)
        {
            slider = GameObject.FindWithTag("BossHealth").GetComponent<Slider>();
        }
    }

	void Start()
	{
		slider.maxValue = bossHealth.currentHealth;
	}

	// Update is called once per frame
	void Update()
    {
		slider.value = bossHealth.currentHealth;
    }

    public void Defeat()
    {
        Destroy(slider.gameObject);
    }
}