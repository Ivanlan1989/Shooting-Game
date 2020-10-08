<<<<<<< HEAD
﻿using System.Collections;
=======
﻿using System;
using System.Collections;
>>>>>>> b4b9ae3276c4e915d1d38822ea3ea1a72fdeeea4
using UnityEngine;
using UnityEngine.UI;

public class FinalStageComplete : MonoBehaviour
{
    #region Variables
    #region Public
    public GameObject player;
    public string stageCompletedMessage;
    public Text stageCompletedText;
    public GameObject stageCompletedGO;
    public float stageCompletedMessageDuration = 4f;
<<<<<<< HEAD
    public GameObject levelLoader;
=======
    public GameObject loadingScreen;
    public GameObject levelLoader;
    public int nextScene;
>>>>>>> b4b9ae3276c4e915d1d38822ea3ea1a72fdeeea4
    #endregion
    #region Private
    private bool isStageComplete;
    #endregion
    #endregion
    #region Collision Callbacks
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (!isStageComplete)
            {
                StartCoroutine(StageCompletedUIMessage());
                isStageComplete = true;
                LoadNextLevel();
            }
        }
    }

    private Text FindMissingTextObject(string textObjectName)
    {
        Text[] tmpGOS = FindObjectsOfType<Text>();
        Text tmpFoundText = null;
        foreach (Text tmpTextObject in tmpGOS)
        {
            if (tmpTextObject.name == textObjectName)
            {
                tmpFoundText = tmpTextObject;   
                break;
            }
        }
        return tmpFoundText;
    }

    private GameObject FindMissingGameObject(string gameObjectName)
    {
        GameObject[] tmpGOS = FindObjectsOfType<GameObject>();
        GameObject tmpFoundGO = null;
        foreach (GameObject tmpGO in tmpGOS)
        {
            if (tmpGO.name == gameObjectName)
            {
                tmpFoundGO = tmpGO;
                break;
            }
        }
        return null;
    }

    private IEnumerator StageCompletedUIMessage()
    {
        Debug.Log(stageCompletedMessage);
        if (stageCompletedText == null)
        {
            stageCompletedText = FindMissingTextObject("Stage Completed");
        }
        if (stageCompletedText == null)
        {
            stageCompletedGO = FindMissingGameObject("Stage Completed");
        }
        stageCompletedText.text = stageCompletedMessage;
        stageCompletedGO.SetActive(true);
        yield return new WaitForSeconds(stageCompletedMessageDuration);
        stageCompletedGO.SetActive(false);
    }

    private void LoadNextLevel()
    {
<<<<<<< HEAD
        LevelLoader tmpLevelLoader = levelLoader.GetComponent<LevelLoader>();
        
=======
        try
        {
            loadingScreen.SetActive(true);
            levelLoader.GetComponent<LevelLoader>().LoadLevel(nextScene);
        }
        catch(Exception ex)
        {
            Debug.LogError("Error " + ex.Message + "\n" + ex.StackTrace);
        }
>>>>>>> b4b9ae3276c4e915d1d38822ea3ea1a72fdeeea4
    }
    #endregion

    #region Public Methods
    public bool IsStageComplete()
    {
        return isStageComplete;
    }
    #endregion
}
