using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    [Header("Audio")]
    
    public AudioSource aud;
    public AudioClip playerHurtClip;
    public AudioClip hitEnemyClip;
    public AudioClip enemyDeadClip;
    [Range(0f, 1f)]
    public float volume = .5f;

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       if(Input.GetButtonDown("Jump"))
       {
           jump = true;
           animator.SetBool("IsJumping", true);
       }

       if(Input.GetButtonDown("Crouch"))
       {
           crouch = true;
       }
       else if (Input.GetButtonUp("Crouch"))
       {
           crouch = false;
       }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boing")
        {
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        //move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
