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
   
  
}
