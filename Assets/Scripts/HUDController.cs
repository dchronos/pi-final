using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public CharacterController character;
	public Text courageText;
	public Text potionsCount;
	public CouragePotion couragePotions;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PointerClick() {
		if(couragePotions.collectedPotions > 0 && character.stressLevel > 0) {
			if (gameObject.tag == "HUDPotion") {
				character.stressLevel -= 1;
				couragePotions.collectedPotions -= 1;
				potionsCount.text = couragePotions.collectedPotions.ToString ();
				courageText.text = character.stressLevel.ToString ();
			}
		}
	}
}
