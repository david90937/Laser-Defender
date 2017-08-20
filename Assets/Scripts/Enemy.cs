using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float Health;
	public GameObject LaserPrefab;
	public float LaserVelocity;
	public float RateofFire;
	public int points;
	private ScoreKeeper scoreKeeper;
	// Use this for initialization
	void Start () {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float Probability = Time.deltaTime * RateofFire;
		if (Random.value < Probability) {
		Attack(); }


	}
	

	void OnTriggerEnter2D (Collider2D trigger)
	{
		Projectile Laser = trigger.gameObject.GetComponent<Projectile> ();
		if (Laser) {
			Destroy (trigger.gameObject);
			Health = Health - trigger.gameObject.GetComponent<Projectile> ().GetDamage (); 
		}
		if (Health <= 0f) {
			Destroy (gameObject);
			scoreKeeper.Score(points);
			GameObject.Find("EnemySpawner").GetComponent<AudioSource>().Play();} 
	}


	void Attack ()
	{
		float LaserPos = transform.position.y - 0.793f;
		GameObject Laser2 = Instantiate (LaserPrefab, new Vector3 (transform.position.x, LaserPos, transform.position.z), Quaternion.identity) as GameObject;
		Laser2.GetComponent<Rigidbody2D>().velocity = new Vector3 (0f, -LaserVelocity, 0f);
		gameObject.GetComponent<AudioSource>().Play(); 
	}
}