using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //[SerializeField] int scene;

    public void StartGame()
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
