using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Jumping : MonoBehaviour //name of script class
{
    private Vector2 V = new Vector2(0,0);
    private Rigidbody2D GuyRb2D; //ridgidbody for the plane
    public Vector2 jumpForce = new Vector2(0, 2000); // creating s vector for the planes jumpforce 

    public PlayerInput playerInput; // player input 
    private InputAction jump; // creating input action called jump
    private InputAction move; // creating input action called jump
    private InputAction restart; // creating input action called restart
    private InputAction quit; // creating input action called quit

    public GameObject player;
    public bool Moving;
    public float speed = 15;  //setting speed to 10
    private float moveDirection;

    public AudioClip punch;



    // Start is called before the first frame update
    void Start()
    {
        GuyRb2D = GetComponent<Rigidbody2D>(); // grabbing the rigidbody of the plane 

        playerInput.currentActionMap.Enable(); // activating the play input map
        jump = playerInput.currentActionMap.FindAction("Jump"); // finding the string  jump 
        move = playerInput.currentActionMap.FindAction("Move"); // finding the string  jump 
        restart = playerInput.currentActionMap.FindAction("RestartGame"); // finding the string restartgame 
        quit = playerInput.currentActionMap.FindAction("QuitGame"); // finding the string quitgame 

        jump.started += Jump_started;
        quit.started += quit_started;
        restart.started += restart_started;
        move.started += Move_started;
        move.canceled += Move_canceled;

        //   restartText.gameObject.SetActive(false);


        // flags 

        // makes plane not react to gravity

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * 0, 0);
            GuyRb2D.AddForce(V);
           // print("hi");
        }
        else 
        {
            GuyRb2D.AddForce(jumpForce); // adding force for the plane to jump
            AudioSource.PlayClipAtPoint(punch, transform.position);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            SceneManager.LoadScene(2);
        }
        

    }
    private void quit_started(InputAction.CallbackContext obj)    // function for quit game
    {
        Application.Quit();
    }

    private void restart_started(InputAction.CallbackContext obj) // function for restart game 
    {
        SceneManager.LoadScene(0);
    }

    private void Jump_started(InputAction.CallbackContext obj) // function for jump in game 
    {
        GuyRb2D.bodyType = RigidbodyType2D.Dynamic;

       
           
        
        
    }

    
    private void Move_canceled(InputAction.CallbackContext obj)
    {
        Moving = false; //setting paddle moving to false which is not moving 
    }
    private void Move_started(InputAction.CallbackContext obj)
    {
        Moving = true; //setting paddle moving to true letting you move the paddle
    }
    private void OnDestroy()
    {
        restart.started -= restart_started;
        jump.started -= Jump_started;
        quit.started -= quit_started;
    }
    private void FixedUpdate()
    {
        if (Moving)
        {
            //move the paddle
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * moveDirection, -.5f); // this is the velo for moving the paddle in a direction 
        }
      
    }
    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            moveDirection = move.ReadValue<float>(); // it is reading the value to see if its moving in a positive or negative direction 
        }

    }
}
