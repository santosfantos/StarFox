using UnityEngine;
using System.Collections;
//push up objects
public class addForceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -6)
        {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(transform.up * 5 ,ForceMode2D.Force);

        }
        if (transform.position.y > 11)
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.up * 5,ForceMode2D.Force );

        }
    }
}
