using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Videos: Brackey's Unity Beginner tutorials 1-10
 * Author: Brackeys (Youtube)
 * Date: January 23 2017
 * Type: Tutorial on using Unity
 * Availability: https://www.youtube.com/playlist?list=PLPV2KyIb3jR5QFsefuO2RlAgWEz6EvVi6
 * 
 * Code adapted from these tutorials to learn Unity, this where i learned how to use unity, from Brackey, this was used in my sub branch to when making basic menus
 * User: Sanjeel Nath
 * */

public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume(); //when the escape key is hit it can auto resume or pause
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); //the panel is inactive
        Time.timeScale = 1f; // this sets the game to active state as 0 means unactive
        GamePaused = false; 
        Cursor.lockState = CursorLockMode.Locked; //mouse becomes hidden and locked
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); // activate the panel
        Time.timeScale = 0f;
        GamePaused = true; //so when the update method is called threads are not confused
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionsButton()
    {
        Application.Quit();
    }
}