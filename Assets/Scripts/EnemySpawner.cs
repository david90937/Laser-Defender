using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width;
	public float height = 5f;
	float xmin;
	float xmax;
	float padding = 1f;
	private bool dirRight; 
	public float moveSpeed; 
	public float spawnDelay;
	// Use this for initialization
	void Start ()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 Leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, distance));
		Vector3 Rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, distance));
		xmin = Leftmost.x + padding;
		xmax = Rightmost.x - padding;
		print(xmax);
		print(xmin);

		ReSpawn();
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3 (width, height, 0f)); }
	// Update is called once per frame
	void Update ()
	{
		float LeftEdge = transform.position.x - (0.5f * width);
		float RightEdge = transform.position.x + (0.5f * width);

		if (LeftEdge <= (xmin)) {
			dirRight = true;
		}
		if (RightEdge >= (xmax)) {
			dirRight = false;
		}

		if (dirRight == true) {
			transform.position += (Vector3.right * moveSpeed * Time.deltaTime);
		} else if (dirRight == false) { 
			transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
		}

		if (AllMembersDead()) { 
			SpawnUntilFull();
		}

	}
	Transform NextFreePosition ()
	{
		foreach (Transform childPositionGameObject in transform) { 
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject; }
		} return null;
	}

	bool AllMembersDead () {
		foreach (Transform childPositionGameObject in transform) { 
			if (childPositionGameObject.childCount > 0) {
				return false; }
		} return true;
	}

	void ReSpawn () {
		foreach (Transform child in transform) {
			GameObject Enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			Enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull ()
	{
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject Enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			Enemy.transform.parent = freePosition; }
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay); } 

	}
}
