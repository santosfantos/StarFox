using UnityEngine;
using System.Collections;

public class backGround : MonoBehaviour {
    public GameObject background;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        background.transform.Rotate(Vector3.forward * 4 * Time.deltaTime);
      
    }
}
