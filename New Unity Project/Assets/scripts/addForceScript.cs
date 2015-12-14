using UnityEngine;
using System.Collections;
//push up objects
public class addForceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -1)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 30);

        }
        if (transform.position.y > 11)
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.up * 30);

        }
    }
}
