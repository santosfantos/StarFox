using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float speed;
    //target for bullet
    private Vector2 target;
    private float currentLocationY;
    private float prevLocationY;

    // Use this for initialization
    void Start()
    {
        target = GameManager.targetFire;
        currentLocationY = -8;
        prevLocationY = -8;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLocationY >= prevLocationY)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(60, findy()), speed * Time.deltaTime);
            prevLocationY = currentLocationY;
            currentLocationY = transform.position.y;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(38,findy() - Time.deltaTime * 15f ), speed * Time.deltaTime); 
            
        }
        if ((transform.position.x > 37) || (transform.position.y < -8))
        {
            Destroy(gameObject);
        }

    }
    // calculate y for bullet target
    private float findy(){
         float m = (target.y + 8) / (target.x + 30) ;
         float n = -8 - (m * (-30));
         return 38 * m + n;
     }
   
}
