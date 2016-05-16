using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DraggableItem : MonoBehaviour {

	public Enemy[] enemyVector;
	public Sprite dragImage;
	Vector3 slotPosition;
	public RectTransform slot01;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Drag() {
		Debug.Log ("DRAG");
		transform.position = Input.mousePosition;
	}

	public void BeginDrag() {
		Debug.Log ("BEGIN DRAG");
		GetComponent<Image>().sprite = dragImage;
		GetComponent<RectTransform> ().localScale = new Vector3 (
			GetComponent<RectTransform> ().localScale.x * 2, 
			GetComponent<RectTransform> ().localScale.y * 2,
			GetComponent<RectTransform> ().localScale.z);
		transform.position = Input.mousePosition;
	}

	public void EndDrag() {
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);

		Debug.Log ("Hit: " + hit);
		if (hit != null && hit.collider != null) {
			Debug.Log ("Hit tag: " + hit.collider.tag);
			if (hit.collider.tag == "ItemWindow") {
				enemyVector [2].hasBeenAvoided = true;
				Destroy (gameObject);
				Debug.Log ("SOLTOU NA JANELA");
			} else {
				slotPosition = Camera.main.ScreenToWorldPoint (slot01.GetComponent<RectTransform> ().localScale);
				transform.position = Vector3.Lerp (transform.position, slotPosition, Time.deltaTime * 4.0f);
			}
		} else {
			transform.position = slot01.GetComponent<RectTransform> ().position;
			GetComponent<RectTransform> ().localScale = slot01.GetComponent<RectTransform> ().localScale;
		}
	}
}
