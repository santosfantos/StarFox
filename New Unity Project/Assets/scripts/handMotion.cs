using UnityEngine;
using System.Collections;

public class handMotion : MonoBehaviour {


	public static GameObject sheepToFire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var mousePos = Input.mousePosition;
		mousePos.z = 9;
		var lookPos = Camera.main.ScreenToWorldPoint(mousePos);
		lookPos = lookPos - transform.position;

		float angle = Mathf.Atan2 (lookPos.y, lookPos.x) * Mathf.Rad2Deg - 80;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

	}

}
