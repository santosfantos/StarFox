using UnityEngine;
using System.Collections;

public class loadSheep : MonoBehaviour {

	public static GameObject sheepToFire;
	public static bool hasSheep;
	// Use this for initialization
	void Start () {
		hasSheep = false;
	}
	
	// Update is called once per frame
	void Update () {if (hasSheep == false && nextAmmo.ammo [0] != null) {
			StartCoroutine (loadupSheep());
		}

	}
	IEnumerator loadupSheep(){
		hasSheep = true;

		if (nextAmmo.ammo [0] != null) {
			nextAmmo.ammo [0].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-200, 150));
			yield return new WaitForSeconds (1f);
			//nextAmmo.ammo[0].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			nextAmmo.ammo [0].GetComponent<Rigidbody2D> ().gravityScale = 0;
			//nextAmmo.ammo[0].transform.position = new Vector2(-33,-7);
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = nextAmmo.ammo [0].GetComponent<SpriteRenderer> ().sprite;
			this.gameObject.GetComponent<SpriteRenderer> ().color = nextAmmo.ammo [0].GetComponent<SpriteRenderer> ().color;
			this.gameObject.GetComponent<Renderer> ().enabled = true;
			//yield return new WaitForSeconds(1.5f);

		}

	}
}
