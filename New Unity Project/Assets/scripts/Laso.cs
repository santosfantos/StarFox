using UnityEngine;
using System.Collections;

public class Laso : MonoBehaviour
{
    
    private Vector2 target;
    //boolean if laso is going towords target or going away
    private bool goForword;
	// Bollean if laso already collected a sheep
	public static bool collected = false;
   
    // Use this for initialization
    void Start()
    {
        target = GameManager.targetLaso;
        goForword = true;
		collected = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (goForword == true  && !collected)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target, GameManager.movmentSpeed * Time.deltaTime);
            Vector3 moveDirection = transform.position - new Vector3(0, -8.5f,0);
            if ((moveDirection != Vector3.zero) && (transform.position.x != target.x) && (transform.position.y != target.y))
            {
                Vector2 motionDirection = GetComponent<Rigidbody2D>().velocity.normalized;

                //float angle = Mathf.Atan2(motionDirection.y, motionDirection.x) * Mathf.Rad2Deg;
                //  transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Vector2 dir = GetComponent<Rigidbody2D>().velocity;

                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            }
            else { goForword = false; }

        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,-8), GameManager.movmentSpeed * Time.deltaTime);
            if (transform.position.y == -8)
            {
                Destroy(gameObject);
                GameManager.lasoGo = true;
            }
        }
      
    }
    //Wait function
    IEnumerator waitLaso()
    {
        yield return new WaitForSeconds(10);
    }
}
