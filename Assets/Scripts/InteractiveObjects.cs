using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractiveObjects : MonoBehaviour {

	public Image slot01;
	public Text scriptText;
	public GameObject Fada;

	public GameObject item;
	Vector3 originalPosition;
	GameObject posFinder;

	Vector3 newCarPos;

	Vector3 slotPosition;

	private bool animating = false;
	Transform transformBackup;
	GameObject backupGameObject;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		backupGameObject = new GameObject ();

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) && !animating) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);


			if (hit != null && hit.collider != null) {
				if(hit.collider == gameObject.GetComponent<BoxCollider2D>()) {
					animating = true;
					Fada.GetComponent<FairyScript> ().changeMarkers = false;
					//backupGameObject.transform.position = Fada.GetComponent<FairyScript> ().endMarker.transform.position;

					Debug.Log ("Only one!");
				}
			}
		}

		if (animating) {
			
			Fada.GetComponent<FairyScript> ().endMarker.transform.position = gameObject.transform.position;
			Fada.GetComponent<FairyScript> ().speed = 20;
			if (Fada.transform.position.x >= gameObject.transform.position.x) {
				slotPosition = Camera.main.ScreenToWorldPoint (slot01.transform.position);

				transform.position = Vector3.Lerp (transform.position, slotPosition, Time.deltaTime * 4.0f);

				Vector3 newVector = new Vector3 (0.05f, 0.05f, 0.05f);
				transform.localScale = Vector3.Lerp (transform.localScale, newVector, Time.deltaTime * 2.0f);

				if (Vector3.Distance (transform.position, slotPosition) <= 1f) {
				
					slot01.sprite = GetComponent<SpriteRenderer> ().sprite;
					Fada.GetComponent<FairyScript> ().restartMarkers();
					Fada.GetComponent<FairyScript> ().changeMarkers = true;
					Destroy (gameObject);
				}
			}
		}
	}
}
