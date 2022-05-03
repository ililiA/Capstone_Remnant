using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTrigger : MonoBehaviour
{
    public Slider slider;

    void Awake()
    {
        if(slider == null)
        {
            slider = GameObject.FindWithTag("BossHealth").GetComponent<Slider>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            slider.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
