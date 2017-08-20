using UnityEngine;
using System.Collections;

public class Position1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere(transform.position, 1);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
