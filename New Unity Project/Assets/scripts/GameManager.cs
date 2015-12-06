using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {
    //if there is already a laso
    public static bool lasoGo = true;

    public static float movmentSpeed = 50f;

    public GameObject sheep;
    public GameObject bullet;
    public GameObject laso;
    public GameObject wolf;
    
    public static Vector2 targetFire;
    public static Vector2 targetLaso;
    //cartridge for bullets
    public static Queue<int> cartrodge = new Queue<int>();
    // Use this for initialization
    void Start () {

        
        StartCoroutine(createObject());

        //initialization of cartridge
        for (int i = 0; i < 10; i++)
        {
            cartrodge.Enqueue(1);
        }
    }
    //create objects
    IEnumerator createObject()
    {
        for (int i = 0; i < 10; i++)
        {

            Instantiate(sheep, new Vector2(2, 0), Quaternion.identity);
            yield return new WaitForSeconds(2);
            Instantiate(wolf, new Vector2(2, 0), Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
       
        
       
    }
   
    
        
    
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            targetFire = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            fire();
            
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
        int p = cartrodge.Dequeue();
        if(p == 1)
        {
            Instantiate(bullet, new Vector2(-30, -8), Quaternion.identity);
        }
        
    }
    private void lasoFire()
    {   
        if(lasoGo == true)
        Instantiate(laso, new Vector2(-30, -8), Quaternion.LookRotation(new Vector3(targetLaso.x,targetLaso.y)));
        
        lasoGo = false;
        

    }
}
