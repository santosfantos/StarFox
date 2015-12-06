using UnityEngine;
using System.Collections;

public class SheepBehaviourScript1 : MonoBehaviour {

    private float movmentSpeedY = 0.25f;
    private float movmentSpeedX = 0.02f;

    private bool gotHit;
    // Use this for initialization
    void Start () {
        gotHit = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (gotHit == false)
        {
            transform.position = new Vector2(transform.position.x - movmentSpeedX, transform.position.y + movmentSpeedY);
        } else
        {
            
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-30, -8), GameManager.movmentSpeed * Time.deltaTime);
        }
        if ( transform.position.x < -19)
        {
            GameManager.cartrodge.Enqueue(1);
            Destroy(gameObject);
                  
        }

    }
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.gameObject.tag == "laso")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            gotHit = true;
			Laso.collected = true;

        }
    }
}
