using UnityEngine;
using System.Collections;

public class spirit_destory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -15) Destroy(gameObject);
	}
	void OnCollisionEnter2D(Collision2D objectCollision){
		if (objectCollision.gameObject.tag == "hand") {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			transform.position = new Vector2 (-43, -7);
		}
	}
}
