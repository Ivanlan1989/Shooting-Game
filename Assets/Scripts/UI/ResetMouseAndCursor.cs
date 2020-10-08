using System;
using UnityEngine;
/*
 * Written by Robert Ankersmit
 * I wrote this script to reset the mouse to it's default state of visable and unlocked.
 * This script can start on default
 * if you assign this to a GameObject and then have the onStart set to true -> 
 * then it will reset on startup ->
 * else if onStart false ->
 * then you can reference this script (by either passing it in to the method in question or by simply getting the script from the GameObject and accesing it that way)
 * This means that the code is ResetMouse method is easy to access, and since reseting the mouse to its default state is used frequently.
 * Code does not need to be repeated.
*/

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
