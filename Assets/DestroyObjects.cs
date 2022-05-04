using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;
    public GameObject gameManager;
    public GameObject eventSystem;
    public GameObject BGM;

    void Awake()
    {
        
        if(player == null)
        {
            player = GameObject.Find("Player_Camera");
        }
        if(UI == null)
        {
            UI = GameObject.FindWithTag("UI");
        }
        if(gameManager == null)
        {
            gameManager = GameObject.Find("Game Manager");
        }
        if(eventSystem == null)
        {
            eventSystem = GameObject.FindWithTag("ES");
        }
        if(BGM == null)
        {
            BGM = GameObject.FindWithTag("music");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(player);
        Destroy(UI);
        Destroy(gameManager);
        Destroy(eventSystem);
        Destroy(BGM);
    
        player.SetActive(false);
        UI.SetActive(false);
        gameManager.SetActive(false);
        eventSystem.SetActive(false);
        BGM.SetActive(false);
    }
}
