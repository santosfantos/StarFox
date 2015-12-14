

using UnityEngine;
using System.Collections;


public class Explosion : MonoBehaviour
{
    public float Power;
    public float Radius;

    public GameObject bullet;
    public static bool active; //active function
    // Use this for initialization
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
#if (UNITY_ANDROID || UNITY_IPHONE)

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Vector3 fingerPos = Input.GetTouch(0).position;
			fingerPos.z = 10;
			Vector3 objPos = Camera.main.ScreenToWorldPoint(fingerPos);
			AddExplosionForce(rigidbody2D, Power * 100, objPos, Radius);
		}

#endif

#if (UNITY_EDITOR || UNITY_WEBPLAYER)

        if (Input.GetMouseButtonDown(0) && active)
        {
           
            Vector3 objPos =  transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            
            Collider2D[] colliders = Physics2D.OverlapCircleAll(objPos,Radius);
            active = false;
            foreach (Collider2D item in colliders)
            {
               
                Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
                if (rb != null && item.tag.Equals("wolf"))
                {
                    nextAmmo.score++;
                    item.GetComponent<addForceScript>().enabled = false;
                    item.GetComponent<WolfBehaviourScript1>().enabled = false; 
                    var dir = (item.transform.position - objPos);
                    item.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    item.GetComponent<Rigidbody2D>().AddForce(dir.normalized * Power * Radius);
                   
                    //AddExplosionForceInwards(rb, Power, objPos, Radius);
                }
                
            }
           
            GameManager.vasat = true;
            GameManager.sheepExplodeGo = false;
            
        }
#endif

    }

   
    }



