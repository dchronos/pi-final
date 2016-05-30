using UnityEngine;
using System.Collections;

public class GameFeedback : MonoBehaviour {

	public GameObject dustParticle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);


			if (hit != null && hit.collider != null) {
				if (hit.collider.CompareTag ("wall")) {
					//GameObject dust = (GameObject)Instantiate (dustParticle);
					dustParticle.SetActive(true);
					dustParticle.GetComponent<ParticleEmitter> ().enabled = true;
					dustParticle.transform.position = new Vector3 (
						pos.x,
						pos.y, 
						dustParticle.transform.position.z);
					//Destroy(dust, 1.0f);
					Debug.Log ("Click on Wall " + pos.x);
				}
			}
		} else {
			dustParticle.SetActive(false);
			dustParticle.GetComponent<ParticleEmitter> ().enabled = false;
		}
	}
}
