//this should probably go on the canvas
// this controls all of the screenspace UI i n the level

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // for sliders
using TMPro;

public class UIController : MonoBehaviour
{
    // instead of making this public, we can add to the inspector with [SerializeField]
    [SerializeField]
    private Slider healthSlider, manaSlider;    // we can make multiple variables on the same line

    public void SetHealthSlider(int amount)
    {
        // make sure no one is sending bad data...
        if(amount < 0)
        {
            healthSlider.value = 0;
        }
        if(amount > 100)
        {
            healthSlider.value = 100;
        }

        healthSlider.value = amount;
    }

    public void SetManaSlider(int amount)
    {
        // make sure no one is sending bad data...
        if(amount < 0)
        {
            manaSlider.value = 0;
        }
        if(amount > 100)
        {
            manaSlider.value = 100;
        }
        
        manaSlider.value= amount;
    }
}
