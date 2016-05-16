using UnityEngine;
using System.Collections;

public class FairyScript : MonoBehaviour {
	
	private Vector2 futurePoint;
	private Vector2 pastPoint;
	public GameObject girl;


	public GameObject startMarker;
	public GameObject endMarker;
	public GameObject startMarkerB;
	public GameObject endMarkerB;
	public float speed;
	public bool changeMarkers = true;
	private float startTime;
	private float journeyLength;
	private Rigidbody2D rig;
	private float sort = 5;

	// Use this for initialization
	void Start () {
		startMarkerB = new GameObject ();
		endMarkerB = new GameObject ();
		startMarkerB.transform.position = startMarker.transform.position;
		endMarkerB.transform.position = endMarker.transform.position;
	}
	public void restartMarkers(){
		startMarker.transform.position = girl.transform.position;
		endMarker.transform.position = girl.transform.position;
		startMarker.transform.position = new Vector3(
			startMarker.transform.position.x + 3.0f,
			startMarker.transform.position.y,
			startMarker.transform.position.z);
		endMarker.transform.position = new Vector3(
			endMarker.transform.position.x - 3.0f,
			endMarker.transform.position.y,
			endMarker.transform.position.z);
		speed = 5;
	}

	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, endMarker.transform.position, step);

		if (gameObject.transform.position.x == endMarker.transform.position.x && changeMarkers) {
			Vector3 newVector = startMarker.transform.position;
			startMarker.transform.position = endMarker.transform.position;
			endMarker.transform.position = newVector;
			endMarker.transform.position = new Vector3(endMarker.transform.position.x, Random.Range(-3.0f, 3.0f), -1);
			int orderLayer =  Random.Range(4,6);
			gameObject.GetComponent<SpriteRenderer> ().sortingOrder = orderLayer;
			gameObject.GetComponent<ParticleSystemRenderer> ().sortingOrder = orderLayer;

		}


	}
}