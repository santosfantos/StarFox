using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {
    public float speed;

    private bool active;
    //target for bullet
    private Vector2 target;
    private Vector2 vectorDirecton;

   
    // Use this for initialization
    void Start () {
        target = GameManager.targetFire;
        active = true;
		Vector2 heading = target - new Vector2(-31.5f,-7f);

		GetComponent<Rigidbody2D>().AddForce(heading * speed,ForceMode2D.Force);
     
        
    }
	
	// Update is called once per frame
	void Update () {
        
        
        if ((transform.position.x > 37) || (transform.position.y < -9) || (transform.position.x < -37))
        {
            Destroy(gameObject);
            GameManager.sheepExplodeGo = false;
            GameManager.vasat = false;

        }
        if (Input.GetMouseButtonDown(0) && active == true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GameManager.vasat = true;
            
            GameManager.sheepExplodeGo = false;
            active = false;
        }
    }
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.gameObject.tag == "wolf")
        {
            Explosion.collision = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;

        }
    }
}
