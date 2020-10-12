using UnityEngine;
/*
 * Written by Robert Ankersmit
 * I did base this in part on the Brackeys Billboard from the Health Bar tutorial, however I completely reworked the billboard to suit my own needs.
 * For example if the cammera cannot be found -> then my script will look for the camera and set the camera to the found camera.
 * This makes my billboard quite good, if for instance you forget to assign the camera then the scrip will be able to adapt and there will be no problems.
 * Brackeys URL: https://www.youtube.com/watch?v=BLfNP4Sc_iA
*/
public class Billboard : MonoBehaviour
{
    #region Variables
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Transform camera;
    public string cameraName = "Normal Camera";
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    #endregion

    void LateUpdate()
    {
        if (camera == null)
        {
            GameObject[] tmpGOS = FindObjectsOfType<GameObject>();
            foreach (GameObject tmpGO in tmpGOS)
            {
                if (tmpGO.name == cameraName)
                {
                    camera = tmpGO.transform;
                    Debug.Log("Found " + camera.name);
                    break;
                }
            }
        }
        if (camera != null)
        {
            transform.LookAt(transform.position + camera.forward);
        }
    }
}
