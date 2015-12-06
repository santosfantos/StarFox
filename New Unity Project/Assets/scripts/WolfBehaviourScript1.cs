using UnityEngine;
using System.Collections;

public class WolfBehaviourScript1 : MonoBehaviour {
    private float y1;
    // Use this for initialization

    void Start () {
        //random y axis 
        y1 = Random.Range(0, 0.5F);

        
    }
   
    // Update is called once per frame
    void Update () {
        transform.position = new Vector2(transform.position.x - 0.02f, transform.position.y + y1);
    }
    //onCollision destory
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.gameObject.tag == "bullet")
        {

            Destroy(gameObject);
        }
    }
}
