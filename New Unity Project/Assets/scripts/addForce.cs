﻿using UnityEngine;
using System.Collections;
//push up objects
public class addForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -1)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 30);

        }
    }
}
