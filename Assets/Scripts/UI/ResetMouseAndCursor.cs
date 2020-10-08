using System;
using UnityEngine;

public class ResetMouseAndCursor : MonoBehaviour
{
	#region Variables
	#region Public Variables
	public bool onStart = false;
	#endregion
	#region Private Variables
	
	#endregion
	#endregion
	
	#region Public Methods
	public void ResetMouse()
    {
		try
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		catch (Exception ex)
		{
			Debug.LogError("Error " + ex.Message + "\n" + ex.StackTrace);
		}
	}
	#endregion
	
	#region Private Methods
	#region MonoBehaviour Methods
    private void Start()
    {
		if (onStart)
		{
			ResetMouse();
		}
    }
	#endregion
	
	#endregion
}
