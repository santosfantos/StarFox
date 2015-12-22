using UnityEngine;
using System.Collections;

public class bullet4 : MonoBehaviour {



	// Use this for initialization
	void Awake () {
		StartCoroutine (slowMotion ());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator slowMotion()
	{
		Time.timeScale = 0.5f;
		yield return new WaitForSeconds(1.5f);
		Time.timeScale = 1f;
		Destroy (gameObject);
	}
}
