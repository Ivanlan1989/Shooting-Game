using UnityEngine;

public class Billboard : MonoBehaviour
{
    #region Variables
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Transform camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    #endregion

    void LateUpdate()
    {
        if (camera == null)
        {
            GameObject[] tmpGOS = FindObjectsOfType<GameObject>();
            foreach (GameObject tmpGO in tmpGOS)
            {
                if (tmpGO.name == "Normal Camera")
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
