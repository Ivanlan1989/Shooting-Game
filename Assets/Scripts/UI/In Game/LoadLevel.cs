using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadLevel : MonoBehaviour
{
    #region Variables
    //public
    public GameObject loadingScreen;
    public Slider loadingBar;
    public Text loadingBarProgressText;
    #endregion

    public void LoadNewLevel(int sceneIndex)
    {
        try
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
            //hide cursor from loading screen
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        catch (Exception ex)
        {
            Debug.Log("Error in trying to load scene from main menu (using loading screen).\n" + ex.Message + "\nStack Trace: " + ex.StackTrace);
        }
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = null;
        if (sceneIndex >= 0)
        {
            operation = SceneManager.LoadSceneAsync(sceneIndex);
        }
        if (!loadingScreen.activeSelf)
        {
            loadingScreen.SetActive(true);
        }
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.value = progress;
            loadingBarProgressText.text = (progress * 100f) + "%";
            Debug.Log((progress * 100f) + "%");//for testing purposes
            //WaitForSeconds(16.8f);//just for testing only
            yield return null;
        }
    }
}
