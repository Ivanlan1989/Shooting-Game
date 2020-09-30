using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    #region Variables
    public GameObject playerControls;
    #endregion

    #region Monobehaviour Callbacks
    private void Update()
    {
        if (Input.GetButtonDown("Player Controls"))
        {
            if (!playerControls.activeInHierarchy)
            {
                playerControls.SetActive(true);
            }
            else
            {
                playerControls.SetActive(false);
            }
        }
    }
    #endregion
}
