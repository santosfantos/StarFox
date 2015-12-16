using UnityEngine;
using System.Collections;

public class Bullet3 : MonoBehaviour {
    public float Radius;
    public float speed;

    private int hits = 0;
    private bool jumpoff = true;
    private bool active = true;
    //target for bullet
    private Vector2 target;
    private Vector2 vectorDirecton;
    // Use this for initialization
    void Start () {
        target = GameManager.targetFire;

        vectorDirecton = new Vector2(target.x, Mathf.Abs(-8 - target.y));
        GetComponent<Rigidbody2D>().AddForce(vectorDirecton * speed, ForceMode2D.Force);
    }
	
	// Update is called once per frame
	void Update () {
        if ((transform.position.x > 37) || (transform.position.y < -9))
        {
            Destroy(gameObject);
        }
        if (hits == 2)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D objectCollision)
    {
       
        if (objectCollision.gameObject.tag == "wolf")
        {
            objectCollision.gameObject.GetComponent<Collider2D>().enabled = false;
            objectCollision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
            objectCollision.gameObject.GetComponent<WolfBehaviourScript1>().enabled = false;
            objectCollision.gameObject.GetComponent<addForceScript>().enabled = false;
            nextAmmo.score++;
            hits++;
           
            Vector3 objPos = transform.position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(objPos, Radius);
            if (active == true)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i] != null && colliders[i].tag.Equals("wolf"))
                    {
                        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        Vector2 dir = (colliders[i].transform.position - objPos);
                        GetComponent<Rigidbody2D>().AddForce(dir * (speed ));
                        active = false;
                        break;
                    }
                }
                            
            }                    

        }
    }
    
    IEnumerator jump()
    {
    
    yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().AddForce(vectorDirecton * (speed / 4), ForceMode2D.Force);
        jumpoff = false;
    }
}
