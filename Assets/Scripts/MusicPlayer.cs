using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	public AudioClip StartClip;
	public AudioClip Level_01;
	public AudioClip LoseClip;

	private AudioSource Music;

	void Start ()
	{
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			Music = gameObject.GetComponent<AudioSource> ();
			Music.clip = StartClip;
			Music.loop = true;
			Music.Play();
		}
	}

	public void OnLevelWasLoaded (int Level) {
		print ("Music Player loaded level "); 
		Music.Stop ();
		if (Level == 0) {
			Music.clip = StartClip;}
		if (Level == 1) {
			Music.clip = Level_01;}
		if (Level == 2) {
			Music.clip = LoseClip;}
		 Music.Play();
	}
		
}
