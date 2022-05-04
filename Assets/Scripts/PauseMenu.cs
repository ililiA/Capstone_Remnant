using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject UI;

    public GameObject pauseMenuUI;
    public GameObject controlMenuUI;

    void Awake()
    {
        if(UI == null)
        {
            UI = GameObject.FindWithTag("UI");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        controlMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        controlMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        controlMenuUI.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:0);
    }

    public void Controls()
    {
        pauseMenuUI.SetActive(false);
        controlMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
