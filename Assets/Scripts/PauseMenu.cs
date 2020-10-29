using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public Slider volumeSlider;
    public Toggle[] resolutionToggles;
    public int[] screenRes;
    int ScreenIndex;

    public static bool GamePaused = false;
    public static bool OptionsOn = false;
    public GameObject pauseMenuUI;
    public GameObject OptionsMenuHolder;

    public void start()
    {
       
        ScreenIndex = PlayerPrefs.GetInt("screen index");
        bool isFull = (PlayerPrefs.GetInt("fullscreen")) == 1;
        volumeSlider.value = AudioManager.instance.getVolume();//passes the audio managers current volume
        

        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].isOn = i == ScreenIndex;
        }

        SetFullScreen(isFull);// the player prefs aim to store the current settings
    }


    // Update is called once per frame


    void Update()
    {
        if (!OptionsOn && Input.GetKeyDown(KeyCode.Escape))
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
        else if(Input.GetKeyDown(KeyCode.Escape) && OptionsOn)
        {
            this.back();
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
        pauseMenuUI.SetActive(false);
        OptionsOn = true;
        Time.timeScale = 0f;
        OptionsMenuHolder.SetActive(true);
    }


    public void back()
    {
        OptionsMenuHolder.SetActive(false);
        pauseMenuUI.SetActive(true);
        OptionsOn = false;
    }

    public void SetScreenResolution(int res)
    {
        if(resolutionToggles[res].isOn)
        {
            ScreenIndex = res;
            float aspectRatio = 16 / 9f;// calculate y is dividing the aspect ratio
            Screen.SetResolution(screenRes[res], (int)(screenRes[res] / aspectRatio), false);
            PlayerPrefs.SetInt("screen index", ScreenIndex);
        }
    }

    public void SetFullScreen(bool isFull)
    {
        for(int i =0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFull;
        }

        if(isFull)
        {
            Resolution[] allRes = Screen.resolutions;
            Resolution max = allRes[allRes.Length - 1];
            Screen.SetResolution(max.width, max.height, true);
        }
        else
        {
            SetScreenResolution(ScreenIndex);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFull) ? 1 : 0));
        PlayerPrefs.Save();//stores if it was in fullscreen
    }

    public void SetMasterVolume(float vol)
    {
         AudioManager.instance.SetVolume(vol);

    }
}