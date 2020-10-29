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

public class OptionsMenu : MonoBehaviour
{

    public Slider volumeSlider;
    public Toggle[] resolutionToggles;
    public int[] screenRes;
    int ScreenIndex;

    public static bool GamePaused = false;
    public static bool OptionsOn = false;
    public GameObject optionsObject;

    public void Start()
    {
        ScreenIndex = PlayerPrefs.GetInt("screen index");//revert to last resolution
        bool isFull = (PlayerPrefs.GetInt("fullscreen")) == 1;
        volumeSlider.value = AudioManager.instance.getVolume();

        for(int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].isOn = i == ScreenIndex;
        }

        SetFullScreen(isFull);// the player prefs aim to store the current settings
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            this.Back();
        }
    }


    public void Back()
    {
        optionsObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");//revert the scene back
    }

    public void SetScreenResolution(int res)
    {
        if (resolutionToggles[res].isOn)
        {
            ScreenIndex = res;
            float aspectRatio = 16 / 9f;//mathmatically calculate the height of the display
            Screen.SetResolution(screenRes[res], (int)(screenRes[res] / aspectRatio), false);
            PlayerPrefs.SetInt("screen index", ScreenIndex);
            PlayerPrefs.Save();//save the current index ie 1 or 0 
        }
    }

    public void SetFullScreen(bool isFull)
    {
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFull;
        }

        if (isFull)
        {
            Resolution[] allRes = Screen.resolutions;
            Resolution max = allRes[allRes.Length - 1];
            Screen.SetResolution(max.width, max.height, true);// max side of the display
        }
        else
        {
            SetScreenResolution(ScreenIndex);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFull) ? 1 : 0));
        PlayerPrefs.Save();
    }

    public void SetMasterVolume(float vol)
    {
        AudioManager.instance.SetVolume(vol);
        PlayerPrefs.Save();
    }

}


