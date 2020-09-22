using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;
    public static AudioManager instance;
	
    void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);	//-> Ensures the audio manger will remain regardless of what scene is loaded.
		foreach (Sound s in sounds)		//This way you only need to have one audio manger instead of one per each scene.
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
    }
	
    
    public void Play(string name)
    {
		try
		{
			Sound s = Array.Find(sounds, sound => sound.name == name);
			if (s == null)
			{
				Debug.LogWarning("Audio clip: " + name + " not found.");
				return;
			}
			s.source.Play();
		}
		catch (Exception ex)
        {
			Debug.Log("Error in trying to play audio clip " + name + ".\n" + ex.Message + "\nStack Trace: " + ex.StackTrace);
		}
    }
	
	public void Stop(string name)
	{
		try
		{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.LogWarning("Audio clip: " + name + " not found.");
			return;
		}
		s.source.Stop();
		Debug.Log(name + " stopped.");
		}
		catch (Exception ex)
		{
			Debug.Log("Error in trying to play audio clip " + name + ".\n" + ex.Message + "\nStack Trace: " + ex.StackTrace);
		}
	}
}