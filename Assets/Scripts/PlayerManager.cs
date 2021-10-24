using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool playerAlive = true;

    public GameObject deathEffect;
    public GameObject hand;

    public GameObject crosshair;
    public GameObject gameOverMenu;

    public PauseMenu PauseMenu;
    public void Death()
    {
        if (playerAlive)
        {
            //Set Boolean
            playerAlive = false;

            //Particle Effect
            Instantiate(deathEffect,transform.position,Quaternion.identity);

            //Disable PauseMenu
            PauseMenu.isGameOver = true;

            //Disable Player
            GetComponent<PlayerMovement>().enabled = false;
            hand.SetActive(false);
            crosshair.SetActive(false);

            //Cursor Active
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //Enable GameOverMenu
            gameOverMenu.SetActive(true);

        }
    }
}
