

using UnityEngine;
using System.Collections;


public class Explosion : MonoBehaviour
{
    public float Power;
    public float Radius;

	public ParticleSystem explosion;
    public GameObject bullet;
    public static bool collision; // active explosion
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

        if (Input.GetMouseButtonDown(0) && active || collision)
        {
		StartCoroutine(particle());
            
        }



    }
	IEnumerator particle(){
		Vector3 objPos =  transform.position;
		Instantiate(explosion, objPos, Quaternion.identity);
		explosion.transform.position = objPos;
		explosion.enableEmission = true;
		bullet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(objPos,Radius);
		active = false;
		collision = false;
		foreach (Collider2D item in colliders)
		{

			Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
			if (rb != null && item.tag.Equals("wolf"))
			{
				nextAmmo.score++;
				GameManager.wolfcounter++;
		print(item);

				item.GetComponent<addForceScript>().enabled = false;
				item.GetComponentInChildren<ParticleSystem>().enableEmission = true; 
				var dir = (item.transform.position - objPos);
				item.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
				item.GetComponent<Rigidbody2D>().AddForce(dir.normalized * Power * Radius);
				item.GetComponent<Rigidbody2D>().gravityScale = 1f;


			}

		}

		GameManager.vasat = true;
		GameManager.sheepExplodeGo = false;
		yield return new WaitForSeconds(2);
		foreach (Collider2D item in colliders) {
		if(item.tag.Equals("wolf"))
 			item.GetComponentInChildren<ParticleSystem>().enableEmission = false;
		}
		Destroy (explosion);   
	}
#endif 
    }



