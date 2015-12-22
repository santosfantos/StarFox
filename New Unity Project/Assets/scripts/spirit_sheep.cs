using UnityEngine;
using System.Collections;
// using only for laso
public class spirit_sheep : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-31.5f, -7f), GameManager.movmentSpeed * Time.deltaTime);
        if (transform.position.x < -31) Destroy(gameObject);
		if (nextAmmo.ammo[0] == null){
			StartCoroutine (jump ());
		}

    }
	IEnumerator jump(){
		yield return new WaitForSeconds (1f);
		this.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-350, 300),ForceMode2D.Force);
	}
}
