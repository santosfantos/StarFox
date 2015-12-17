using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WolfBehaviourScript1 : MonoBehaviour {

    // Use this for initialization
    public float speed = 0.02f;
    private float y1;

    private bool active; // active slow motion

   

    private Vector2 velocity;

    void Start () {
        //random y axis 
        y1 = Random.Range(0, 0.3F);

        
    }
   
    // Update is called once per frame
    void Update () {
        if(active == false) transform.position = new Vector2(transform.position.x - speed, transform.position.y + y1);

        if(transform.position.y < - 15) Destroy(gameObject);

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(bulletSlow());
        }



    }
    //onCollision destory
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.gameObject.tag == "bullet")
        {
            active = true;
            GetComponent<Rigidbody2D>().gravityScale = 1f;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<addForceScript>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            nextAmmo.score++;
        }
        if (objectCollision.gameObject.tag == "bullet2")
        {
            active = true;
            GetComponent<Rigidbody2D>().gravityScale = 1f;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<addForceScript>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            nextAmmo.score++;
        }
    }
    IEnumerator bulletSlow()
    {
        active = true;
        
        velocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity / 8;
      
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody2D>().velocity = velocity;
        active = false;
       

    }
}
