using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public BossHealth bossHealth;
	public Slider slider;
    public GameObject ui;
    //public GameObject trigger;

    //slider.SetActive(true);

    void Awake()
    {
        /*
        if(slider == null)
        {
            slider = GameObject.FindWithTag("BossHealth").GetComponent<Slider>();
        }
        */
        if(ui == null)
        {
            ui = GameObject.FindWithTag("UI");
        }
        if(slider == null)
        {
            //slider = ui.GetComponent<Slider>();
            slider = ui.transform.Find("BossHealth").GetComponent<Slider>();
            Debug.Log("finding health bar");
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
        //Destroy(slider.gameObject);
        Destroy(this.gameObject);
        Debug.Log("defeated boss");
    }
    public void DeleteHealth()
    {
        Destroy(slider.gameObject);
        Debug.Log("deleting health bar");
    }
}