using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjects : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;
    public GameObject gameManager;
    public GameObject eventSystem;

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

    }
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        UI.SetActive(false);
        gameManager.SetActive(false);
        eventSystem.SetActive(false);
    }

    public void Enable()
    {
        player.SetActive(true);
        UI.SetActive(true);
        gameManager.SetActive(true);
        eventSystem.SetActive(true);
    }
}
