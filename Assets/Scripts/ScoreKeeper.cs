using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	// Use this for initialization
	public int score;  
	public Text text;

	void Start () {
		Reset();
		gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Score (int points)
	{
		score = score + points;
		text.text = "Score: " + score.ToString();
	}

	public void Reset ()
	{
		score = 0;
	}
}
