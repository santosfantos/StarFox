using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WolfBehaviourScript1 : MonoBehaviour {

    // Use this for initialization
    public float speed;
	public static float y1;

    private bool active; // active slow motion


    private Vector2 velocity;

    void Start () {
        //random y axis 
		//y1 = Random.Range(10f, 14F);

        
    }
   
    // Update is called once per frame
    void Update () {
		if(active == false) transform.Translate(new Vector3(-speed,y1,0) * Time.deltaTime);

		if (transform.position.y < -15) {
			Destroy (gameObject);
		}
		if (transform.position.x < -30) {
			Destroy (gameObject);
			GameManager.life--;
		}
       /*if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(bulletSlow());
        }*/



    }
    //onCollision destory
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.gameObject.tag == "bullet")
        {
            active = true;
            GetComponent<Rigidbody2D>().gravityScale = 1f;
            
            GetComponent<addForceScript>().enabled = false;
         //   GetComponent<Collider2D>().enabled = false;
            nextAmmo.score++;
			GameManager.wolfcounter++;
        }
        if (objectCollision.gameObject.tag == "bullet2")
        {
            active = true;
            GetComponent<Rigidbody2D>().gravityScale = 1f;
            
            GetComponent<addForceScript>().enabled = false;
          //  GetComponent<Collider2D>().enabled = false;
            nextAmmo.score++;
			GameManager.wolfcounter++;
        }
		if (objectCollision.gameObject.tag == "bullet3")
		{
			active = true;
			GetComponent<Rigidbody2D>().gravityScale = 1f;

			GetComponent<addForceScript>().enabled = false;
			//GetComponent<Collider2D>().enabled = false;
			nextAmmo.score++;
			GameManager.wolfcounter++;
		}
    }
  /*  IEnumerator bulletSlow()
    {
        active = true;
        
        velocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity / 2;
      
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody2D>().velocity = velocity;
        active = false;
       

    }*/
	
}
