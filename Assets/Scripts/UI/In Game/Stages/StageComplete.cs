using UnityEngine;

public class StageComplete : MonoBehaviour
{
    #region Variables
    #region Public
    public GameObject player;
    public string message;
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
                Debug.Log(message);
                isStageComplete = true;
            }
        }
    }
    #endregion

    #region Public Methods
    public bool IsStageComplete()
    {
        return isStageComplete;
    }
    #endregion
}
