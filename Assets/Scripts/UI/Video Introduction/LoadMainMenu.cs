using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Author: Robert Ankersmit
 * I wrote this all myself, however I did take some inspiration from a tutorial video.
 * I had a look at the tutorial to get an idea of how to create an introduction with a video player.
 * However I wrote all the code myself, in my own way. As stated, I simply took the insperation and extrapolated the overall concept and made it myself.
 * URL: https://www.youtube.com/watch?v=2kLQ8gq9xeQ&t=557s
 */

public class LoadMainMenu : MonoBehaviour
{
	#region Variables
	#region Public Variables
	public string sceneToLoad;
	public float videoLength;
	#endregion
	#region Private Variables
	private bool canLoadNextScene = false;
	#endregion
	#endregion
	
	#region Public Methods
	
	#endregion
	
	#region Private Methods
	#region MonoBehaviour Methods
    private void Start()
    {
		StartCoroutine(WaitForVideoToFinishPlaying());
    }
	#endregion
	private void LoadNewScene()
    {
        try
        {
			SceneManager.LoadScene(sceneToLoad);
        }
		catch (Exception ex)
        {
			Debug.LogError("Error in loading new scene -> " + ex.Message + "\n" + ex.StackTrace);
        }
    }

	private IEnumerator WaitForVideoToFinishPlaying()
    {
		yield return new WaitForSeconds(videoLength);
		LoadNewScene();
    }
	#endregion
}
