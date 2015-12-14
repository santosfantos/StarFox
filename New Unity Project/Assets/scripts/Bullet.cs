using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float speed;
    //target for bullet
    private Vector2 target;
    private Vector2 vectorDirecton;
    // Use this for initialization
    void Start()
    {
        target = GameManager.targetFire;
        
        vectorDirecton = new Vector2( target.x, Mathf.Abs(-8 - target.y));
        GetComponent<Rigidbody2D>().AddForce(vectorDirecton * speed);
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if ((transform.position.x > 37) || (transform.position.y < -9))
        {
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.gameObject.tag == "wolf")
        {   
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
           
        }
    }
// calculate y for bullet target
private float findy(){
         float m = (target.y + 8) / (target.x + 30) ;
         float n = -8 - (m * (-30));
         return 38 * m + n;
     }
   
}
