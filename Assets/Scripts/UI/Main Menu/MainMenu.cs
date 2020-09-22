using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        try
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        catch (Exception ex)
        {
            Debug.Log("Error in trying to load scene from main menu.\n" + ex.Message + "\nStack Trace: " + ex.StackTrace);
        }
    }

    public void QuitGame()
    {
        try
        {
            Debug.Log("Game has now quit.");
            Application.Quit();
        }
        catch (Exception ex)
        {
            Debug.Log("Error in trying to quit game from main menu.\n" + ex.Message + "\nStack Trace: " + ex.StackTrace);
        }
    }
}
