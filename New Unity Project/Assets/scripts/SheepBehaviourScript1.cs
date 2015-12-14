using UnityEngine;
using System.Collections;

public class SheepBehaviourScript1 : MonoBehaviour {

    private float movmentSpeedY = 0.2f;
    private float movmentSpeedX = 0.02f;

    static bool gotHit; // got hit by laso
    private bool active; // active slow motion

    private Vector2 velocity;
    public GameObject sheep;
    public GameObject bullet;
    // Use this for initialization
    void Start () {
        gotHit = false;
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (active == false)
        {
            transform.position = new Vector2(transform.position.x - movmentSpeedX, transform.position.y + movmentSpeedY);
        }

        if ( transform.position.y == -8 && transform.position.x == 0)
        {
           // nextAmmo.cartrodge.Enqueue();
            Destroy(gameObject);
                  
        }

        if (Input.GetKeyDown(KeyCode.S)){
            StartCoroutine( bulletSlow());
        }

    }
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.gameObject.tag == "laso")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            gotHit = true;
			Laso.collected = true;
            Destroy(gameObject);
            Instantiate(sheep, transform.position, Quaternion.identity);
            nextAmmo.cartrodge.Enqueue(bullet);
           

        }
    }
    IEnumerator bulletSlow()
    {
        active = true;
        // GetComponent<Rigidbody2D>().AddForce(-GetComponent<Rigidbody2D>().velocity / 8);
        // movmentSpeedX = movmentSpeedX / 2;
        // movmentSpeedY = movmentSpeedY / 16;
        velocity = GetComponent<Rigidbody2D>().velocity;
       GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity / 8;
      //GetComponent<Rigidbody2D>().gravityScale = GetComponent<Rigidbody2D>().gravityScale / 2;
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody2D>().velocity = velocity;
        active = false;
        //GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * 4;
       
    }
}
