using System;
using System.Collections;
using UnityEngine;
/*
 * Written by Robert Ankersmit
*/
public class AllSinglePlayerLevelsCompleted : MonoBehaviour
{
	#region Variables
	#region Public Variables
	public GameObject loadingScreen;
	public GameObject levelLoader;
	public string nextScene;
	public float delay = 6f;
	public ResetMouseAndCursor resetMouse;
	#endregion
	#region Private Variables

	#endregion
	#endregion

	#region Public Methods

	#endregion

	#region Private Methods
	#region MonoBehaviour Methods
	private void Start()
    {
		StartCoroutine(Delay());
    }
	#endregion
	private IEnumerator Delay()
    {
		yield return new WaitForSeconds(delay);
		LoadNextLevel();
    }

	private void LoadNextLevel()
	{
		try
		{
			loadingScreen.SetActive(true);
			levelLoader.GetComponent<LevelLoader>().LoadLevel(nextScene);
			resetMouse.ResetMouse();
		}
		catch (Exception ex)
		{
			Debug.LogError("Error " + ex.Message + "\n" + ex.StackTrace);
		}
	}
	#endregion
}
