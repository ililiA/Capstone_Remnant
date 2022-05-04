// handle collision with enemies and firing magic
// haarryy?                sIr
// advanced potions like felix felicis too
// sound of silence

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth hp;

    [SerializeField]
    private PlayerHealth mana;

    public float regenTimer = 1, damageRegenInterval = 5;

    private PlayerSaveAndLoad save;
    //public GameManager transition;
    public UIController ui;
    //public Rigidbody2D rb;

    public int key = 0;

    void Start()
    {
        /*
        if(rb == null)
        {
            rb = this.GetComponent<Rigidbody2D>();
        }
        */
        
        if(hp == null)
        {
            hp = this.GetComponent<PlayerHealth>();
        }
        if(mana == null)
        {
            mana = this.GetComponent<PlayerHealth>();
        }

        save = this.GetComponent<PlayerSaveAndLoad>();
        //this means it's on the same object!!!
        //if script function is on another object you have to find the other object then the script
        //transition = GameObject.Find("Game Manager").GetComponent<GameManager>();

        /*
        rb.velocity = Vector2.zero;                 //set speed to zero
        rb.angularVelocity = Vector2.zero;          //set rotation to zero
        */
    }

    // this should go to the input manager script
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(hp.mana > 0)
            {
                hp.ChangeMana(-25);
                hp.ChangeHealth(+20);
            }
        }

        /*
        if(Input.GetKeyDown(KeyCode.Q))
        {
           
        }
        */
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("BossStay"))
        {
            Debug.Log("I'm hurt!"); 
            if(regenTimer > damageRegenInterval)
            {
                regenTimer = 0;
                hp.ChangeHealth(-5);
            }
            else
            {
                regenTimer += Time.deltaTime;
            }
        }
    }
    
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I'm hurt!"); 
            hp.ChangeHealth(-10);
            //taking damage
        }
        if(other.gameObject.CompareTag("BossStay"))
        {
            return;
        }

        if(other.gameObject.CompareTag("enemyAreaTransition"))
        {
            Debug.Log("running transition");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:3);
            //transition.Transition();
            //load next scene
        }
        if(other.gameObject.CompareTag("bossAreaTransition"))
        {
            Debug.Log("running transition");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:4);
        }
        if(other.gameObject.CompareTag("startingAreaTransition"))
        {
            Debug.Log("running transition");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:7);
        }
        if(other.gameObject.CompareTag("finalAreaTransition"))
        {
            Debug.Log("running transition");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:6);
        }
        if(other.gameObject.CompareTag("credits"))
        {
            Debug.Log("running transition");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:9);
        }


        /*
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            //call the save function
            save.Save();
        }
        /*
        else if(other.gameObject.CompareTag(""))
        {
            Debug.Log("running transition");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:0);
            transition.Transition();
        }

        Debug.Log(other.tag);
        if(other.gameObject.CompareTag("Key"))
        {
            key += 1;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("BossGate"))
        {
            if(key == 3)
            {    
                key -= 3;
                
                Debug.Log("running transition");
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex:3);
                transition.Transition();
            }
            else
            {
                Debug.Log("You need all three keys to unlock the gate!");
            }
        }
        */
    }
}