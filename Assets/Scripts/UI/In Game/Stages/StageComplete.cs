using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StageComplete : MonoBehaviour
{
    #region Variables
    #region Public
    public GameObject player;
    public string stageCompletedMessage;
    public Text stageCompletedText;
    public GameObject stageCompletedGO;
    public float stageCompletedMessageDuration = 4f;
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
            }
        }
    }

    private IEnumerator StageCompletedUIMessage()
    {
        Debug.Log(stageCompletedMessage);
        stageCompletedText.text = stageCompletedMessage;
        stageCompletedGO.SetActive(true);
        yield return new WaitForSeconds(stageCompletedMessageDuration);
        stageCompletedGO.SetActive(false);
    }
    #endregion

    #region Public Methods
    public bool IsStageComplete()
    {
        return isStageComplete;
    }
    #endregion
}
