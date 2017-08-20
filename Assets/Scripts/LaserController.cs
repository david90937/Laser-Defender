using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	public PlayerController Ship;
	public GameObject Laser;
	public GameObject EnemyLaser;
	//public float LaserVelocity;



	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.Translate (0f, (1 * LaserVelocity * Time.deltaTime), 0f);
		if (transform.position.y > 5f) {     
			DestroyObject (Laser);
		}
		if (transform.position.y < -10f) {
			DestroyObject (EnemyLaser);
		}
	}
	void OnCollisionEnter2D (Collision2D col) {
		//print("Hit a bogey"); 
		//Destroy(this.gameObject);
	}
}

