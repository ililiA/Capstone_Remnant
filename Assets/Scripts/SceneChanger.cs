using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    DisableObjects disabledObjects;

    void Awake()
    {
        disabledObjects = GameObject.Find("Destroy").GetComponent<DisableObjects>();
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:8);
    }
    public void Skip()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:2);
    }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:0);
    }
    public void ControlMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Retry()
    {
        disabledObjects.GetComponent<DisableObjects>().Enable();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
