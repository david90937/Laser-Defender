using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	public void LoadNextLevel ()
	{
		GameObject.Find("Music Player").GetComponent<MusicPlayer>().OnLevelWasLoaded(Application.loadedLevel +1); 
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
