using UnityEngine;
using System.Collections;

public class spirit_destory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -10) Destroy(gameObject);
	}
}
