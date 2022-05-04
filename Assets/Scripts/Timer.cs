using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int levelToLoad;
    public float timer = 10f;

    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:levelToLoad);
        }
    }
}