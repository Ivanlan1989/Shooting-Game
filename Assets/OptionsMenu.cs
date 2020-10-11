using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public GameObject optionsObject;
    public GameObject PauseMenuHolder;

    public void back()
    {
        optionsObject.SetActive(false);
        PauseMenuHolder.SetActive(true);
    }

    public void SetScreenResolution(int res)
    {

    }

    public void SetFullScreen(bool isFull)
    {

    }

    public void SetMasterVolume(float vol)
    {

    }
}
