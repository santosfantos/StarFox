using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

   
    public static bool lasoGo = true;  //if there is already a laso
    private bool active = true; //active fire
    public static bool sheepExplodeGo = false;  //if there is a sheep exploding bullet
    private bool pause = false; // for pause button
    public static bool vasat = false; //controls 2nd click on bullet2
    private bool doubleShotActive = false;

    public static float movmentSpeed = 50f;

    public GameObject sheep;
    public GameObject laso;
    public GameObject wolf;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;

    public GameObject bullet_spirit;
    public GameObject bullet2_spirit;
    public GameObject bullet3_spirit;

    private GameObject p;
    public Animator anim; // hand animator
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

            Instantiate(wolf, new Vector2(15 , i ), Quaternion.identity) ;
            yield return new WaitForSeconds(0);
        }
       
        
       
    }

   


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.P)) { pauseGame(); }
        if (Input.GetKeyDown(KeyCode.D)) { doubleShot(); }

        if (Input.GetMouseButtonDown(0) && pause == false && active == true)
        {
            if (sheepExplodeGo == false && vasat == false)
            {
               
                targetFire = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                

                StartCoroutine( fire());
                active = false;
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
        if (Input.GetKeyDown(KeyCode.S)) { StartCoroutine (slowMotion()); }
    }
    IEnumerator  fire()
    {
        p = nextAmmo.ammo[0];



        anim.SetBool("Fired", true);
        StartCoroutine(fireAnim());
        
        if (p != null)
        {

            p.GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 250)); // to move first element in queue
            nextAmmo.ammo[0] = null; // to initialize reload
            
            yield return new WaitForSeconds(0.5f);
            if (p.tag == bullet_spirit.tag)
            {
                if(doubleShotActive == true)
                {
                    Instantiate(bullet, new Vector2(0, -7f), Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                    anim.SetBool("Fired", true);
                    StartCoroutine(fireAnim());
                    Instantiate(bullet, new Vector2(0, -7f), Quaternion.identity);
                    
                }
                Instantiate(bullet, new Vector2(0, -7f), Quaternion.identity);
            }
            if (p.tag == bullet2_spirit.tag)
            {
                sheepExplodeGo = true;
                if (doubleShotActive == true)
                {
                    Instantiate(bullet2, new Vector2(0, -7f), Quaternion.identity);

                    anim.SetBool("Fired", true);
                    yield return new WaitForSeconds(0.5f);
                    StartCoroutine(fireAnim());
                    
                }
                
                Instantiate(bullet2, new Vector2(0, -7f), Quaternion.identity);

            }
            if (p.tag == bullet3_spirit.tag)
            {
                if (doubleShotActive == true)
                {
                    Instantiate(bullet3, new Vector2(0, -7f), Quaternion.identity);
                   
                    anim.SetBool("Fired", true);
                    yield return new WaitForSeconds(0.5f);
                    StartCoroutine(fireAnim());
                   
                } 
                
                Instantiate(bullet3, new Vector2(0, -7f), Quaternion.identity);
            }
            
        }
        doubleShotActive = false;
        active = true;
    }
    private void lasoFire()
    {   
        if(lasoGo == true)
        Instantiate(laso, new Vector2(0, -8.5f), Quaternion.LookRotation(new Vector3(targetLaso.x,targetLaso.y)));
        
        lasoGo = false;
        

    }
    private void pauseGame()
    {
        pause = !pause;
        if (Time.timeScale == 1)
        {
            
            Time.timeScale = 0f;
        } else
        {
            
            Time.timeScale = 1f;
        }
    }
    IEnumerator slowMotion()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 1f;
    }
    IEnumerator fireAnim()
    {
            yield return new WaitForSeconds(0.2f);
            anim.SetBool("Fired", false);
            
    }
    private void doubleShot()
    {
        doubleShotActive = true;
    }
}
