using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;

    public GameObject pauseMenu;

    public bool isGameOver = false;

    public GameObject pistol;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            //Set boolean
            isGamePaused = !isGamePaused;

            if (!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    private void PauseGame()
    {
        //Disable Player Movement
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;

        //Disable Pistol
        pistol.GetComponent<WeaponControl>().enabled = false;

        //Set Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Set Time Scale
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }

    private void ResumeGame()
    {
        //Enabled Player Movement
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;

        //Enabled Pistol
        pistol.GetComponent<WeaponControl>().enabled = true;

        //Set Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Set Time Scale
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

    }
}
