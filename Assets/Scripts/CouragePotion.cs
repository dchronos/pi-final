using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CouragePotion : MonoBehaviour {

	public int collectedPotions;
	public CharacterController character;
	public GameObject potion;
	public Text courageText;

	// Use this for initialization
	void Start () {
		collectedPotions = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() { 
		collectedPotions += 1;
		courageText.text = collectedPotions.ToString ();
		Destroy (potion);
	}
}
