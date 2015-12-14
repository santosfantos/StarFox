using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

   
    public static bool lasoGo = true;  //if there is already a laso

    public static bool sheepExplodeGo = false;  //if there is a sheep exploding bullet

    public static bool vasat = false; //controls 2nd click on bullet2

    public static float movmentSpeed = 50f;

    public GameObject sheep;
    public GameObject bullet;
    public GameObject laso;
    public GameObject wolf;
    public GameObject bullet2;

    public GameObject bullet_spirit;
    public GameObject bullet2_spirit;

    private GameObject p;

    public static Vector2 targetFire; //vector for target to fire at
    public static Vector2 targetLaso; //vector for laso to go to

    // Use this for initialization
    void Start () {

        
        StartCoroutine(createObject());

       
        
    }
    //create objects
    IEnumerator createObject()
    {
        for (int i = 0; i < 10; i++)
        {

          Instantiate(sheep, new Vector2(2, 0), Quaternion.identity);
           yield return new WaitForSeconds(2);

            Instantiate(wolf, new Vector2(2 , i ), Quaternion.identity) ;
            yield return new WaitForSeconds(0);
        }
       
        
       
    }

   


    // Update is called once per frame
    void Update () {
       if (Input.GetMouseButtonDown(0))
        {
            if (sheepExplodeGo == false && vasat == false)
            {
               
                targetFire = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                fire();
            }
            else
            {
                
                vasat = false;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            targetLaso = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lasoFire();
        }
        if (Input.GetMouseButtonDown(2)) { }
            
    }
    private void fire()
    {


        p = nextAmmo.ammo[0];
        if (p != null)
        {

            p.GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 250)); // to move first element in queue
            nextAmmo.ammo[0] = null; // to initialize reload


            if (p.tag == bullet_spirit.tag)
            {
                Instantiate(bullet, new Vector2(0, -8), Quaternion.identity);
            }
            if (p.tag == bullet2_spirit.tag)
            {

                sheepExplodeGo = true;
                Instantiate(bullet2, new Vector2(0, -8), Quaternion.identity);

            }

        }
    }
    private void lasoFire()
    {   
        if(lasoGo == true)
        Instantiate(laso, new Vector2(0, -8.5f), Quaternion.LookRotation(new Vector3(targetLaso.x,targetLaso.y)));
        
        lasoGo = false;
        

    }
}
