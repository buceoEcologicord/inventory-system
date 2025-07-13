using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class WorldInteraction : MonoBehaviour
{
    /// <summary>
    /// Assign to an object you want to give interaction. 
    /// This script will handle recognition and activate interaction with the player.
    /// Should assign specific interaction script to each object
    /// </summary>
    /// 

    /// <summary>
    /// Instructions: Tag player with "Player" tag.
    /// Assign collider to the interaction object, set as trigger.
    /// Assign this script to the interaction object.
    /// Assign interactionScript to the specific interaction script that defines the interaction.
    /// Add an interaction sign (Sprite) if desired and assign to this script
    /// Player must have collider too
    /// Add a player input component to the object with this script, additional to the player's (even if it uses the same input asset)
    /// On action map of the player input remove the Hold interaction from Interact action, or reduce the hold time to achieve desired effects 
    /// </summary>

    public MonoBehaviour interactionScript; //To Get the Script that defines the specific interaction of the interaction-object
    public SpriteRenderer interactSign;

    private bool inRange;

    private PlayerInput playerInput; //To get the player input system

    private void Start()
    {
        interactSign.enabled = false;
        //playerInput = FindFirstObjectByType<PlayerInput>(); //Finds player Input to detect when pressing interact button
        //if (playerInput == null)
        //{
        //    Debug.LogError("PlayerInput not found in the scene. Please ensure there is a PlayerInput component in the scene.");
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger");
        if (collision.gameObject.CompareTag("Player"))
            {
                inRange = true;
                Debug.Log("inrange " + inRange);

                //Activates object interaction sign
                InteractSign(true);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
            {
                inRange = false;
                Debug.Log("inrange " + inRange);

            //Dectivates player interaction sign
            InteractSign(false);
        }
    }

    public void OnInteract()
    {
        if (inRange)
        {
            Debug.Log("Interact succesfull");

        }

    }

    public void InteractSign(bool state)
    {
        interactSign.enabled = state;
    }

}
