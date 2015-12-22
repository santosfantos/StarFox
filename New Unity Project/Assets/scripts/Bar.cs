using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {
	public Sprite Bar_full;
	public Sprite Bar_two_lives;
	public Sprite Bar_one_life;
	public Sprite Bar_empty;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int control = GameManager.life;
		switch (control) {
		case 3:
			GetComponent<SpriteRenderer> ().sprite = Bar_full;
			break;
		case 2:
			GetComponent<SpriteRenderer> ().sprite = Bar_two_lives;
			break;
		case 1:
			GetComponent<SpriteRenderer> ().sprite = Bar_one_life;
			break;
		default :
			GetComponent<SpriteRenderer> ().sprite = Bar_empty;
			break;
		}
	}
}
