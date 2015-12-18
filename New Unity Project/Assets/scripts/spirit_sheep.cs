using UnityEngine;
using System.Collections;
// using only for laso
public class spirit_sheep : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, -8.5f), GameManager.movmentSpeed * Time.deltaTime);
        if (transform.position.y < -8) Destroy(gameObject);
    }
}
