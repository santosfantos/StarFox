using UnityEngine;
using System.Collections;

public class SheepBehaviourScript1 : MonoBehaviour {

    private float movmentSpeedY = 10f;
    private float movmentSpeedX = 1.5f;

    static bool gotHit; // got hit by laso
    

    private Vector2 velocity;
    public GameObject sheep;
    public GameObject bullet;
    
    // Use this for initialization
    void Start () {
        gotHit = false;
       
	}
	
	// Update is called once per frame
	void Update () {
      
          
            transform.Translate(new Vector3(-movmentSpeedX,movmentSpeedY,0) * Time.deltaTime);
        
       
        if ( transform.position.y == -8 && transform.position.x == 0)
        {
           // nextAmmo.cartrodge.Enqueue();
            Destroy(gameObject);
                  
        }

       /* if (Input.GetKeyDown(KeyCode.S)){
            StartCoroutine( bulletSlow());
        }*/

    }
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.gameObject.tag == "laso")
        {
            Destroy(gameObject);
            gotHit = true;
			Laso.collected = true;
            Instantiate(sheep,transform.position, Quaternion.identity);
            // Instantiate(sheep, transform.position, Quaternion.identity);
            nextAmmo.cartrodge.Enqueue(bullet);
           

        }
    }
    /*IEnumerator bulletSlow()
    {
        active = true;
       // GetComponent<Rigidbody2D>().AddForce(-GetComponent<Rigidbody2D>().velocity * 4);
       // movmentSpeedX = movmentSpeedX / 4;
        //movmentSpeedY = movmentSpeedY / 4;
       velocity = GetComponent<Rigidbody2D>().velocity;
       GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity / 4;
        //if(GetComponent<Rigidbody2D>().velocity < new Vector2(1,1)) GetComponent<Rigidbody2D>().velocity = velocity;

        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody2D>().velocity = velocity;
        active = false;
        //GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * 4;
       
    }*/
  
}
