using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	float xmin;
	float xmax;
	float padding = 1f;
	public GameObject LaserPrefab;
	public float Health;
	public float LaserVelocity;
	public GameObject Thruster;
	public GameObject Thruster2;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 Leftmost = Camera.main.ViewportToWorldPoint (new Vector3(0f, 0f, distance));
		Vector3 Rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, distance));
		xmin = Leftmost.x + padding;
		xmax = Rightmost.x - padding;
		Thruster = GameObject.Find("Thruster");
		Thruster2 = GameObject.Find("Thruster2");

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.001f, 0.2f);
		} else if(Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke (); } 

		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		Thruster.transform.position = gameObject.transform.position - (new Vector3(.353f, .382f, 0f));
		Thruster2.transform.position = gameObject.transform.position - (new Vector3(-.353f, .382f, 0f));

	}
	 

	void Fire ()
	{
		float LaserPos = transform.position.y + 0.732f;
		GameObject Laser = Instantiate (LaserPrefab, new Vector3 (transform.position.x, LaserPos, transform.position.z), Quaternion.identity) as GameObject;
		Laser.GetComponent<Rigidbody2D>().velocity = new Vector3 (0f, LaserVelocity, 0f);
		gameObject.GetComponent<AudioSource>().Play();	

	}

	void OnTriggerEnter2D (Collider2D trigger)
	{ 
		Projectile Laser = trigger.gameObject.GetComponent<Projectile> ();
		if (Laser) {
			Destroy (trigger.gameObject);
			Health = Health - trigger.gameObject.GetComponent<Projectile> ().GetDamage ();} 
		
		if (Health <= 0f) {
			Destroy (gameObject);
			Destroy(Thruster);
			Destroy(Thruster2);
			GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Lose");}
	}
}
