using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    PlayerHealth hp;
    PlayerHealth mana;

    void Start()
    {
        hp = this.GetComponent<PlayerHealth>();
        Debug.Log("health = " + hp.health);

        mana = this.GetComponent<PlayerHealth>();
        Debug.Log("mana = " + mana.health);
    }

    public void Save()
    {
        Debug.Log("Saved!");

        PlayerPrefs.SetInt("hp", hp.health);
        PlayerPrefs.SetInt("mana", mana.health);

        PlayerPrefs.SetFloat("posX", transform.position.x);
        PlayerPrefs.SetFloat("posY", transform.position.y);
        PlayerPrefs.SetFloat("posZ", transform.position.z);

        Vector3 saveLocation = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));

        Debug.DrawLine(saveLocation, saveLocation + Vector3.up * 50, Color.white, 1000);
                                            
    }

    public void Load()
    {
        Debug.Log("Loading!");

        hp.health = PlayerPrefs.GetInt("hp", 100);
        mana.health = PlayerPrefs.GetInt("mana", 100);

        Vector3 newPosition;

        newPosition.x = PlayerPrefs.GetFloat("posX");
        newPosition.y = PlayerPrefs.GetFloat("posY");
        newPosition.z = PlayerPrefs.GetFloat("posZ");

        this.transform.position = newPosition;
    }

    

    
}