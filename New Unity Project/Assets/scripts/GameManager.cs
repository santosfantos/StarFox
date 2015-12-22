using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public GameObject bullet4;

    public GameObject bullet_spirit;
    public GameObject bullet2_spirit;
    public GameObject bullet3_spirit;
	public GameObject bullet4_spirit;

	public GameObject sheepToFire; // child of "hand"

    private GameObject p;
    public Animator anim; // hand animator
    public static Vector2 targetFire; //vector for target to fire at
    public static Vector2 targetLaso; //vector for laso to go to
	private float random1;
	private float random2;
	public static int life = 3; // life counter
	public static int wolfcounter = 0 ; // counter for the wolf amount on the screen
    // Use this for initialization
    void Start () {
		
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
                //active = false;
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
       
		if (life == 0) {
			Application.LoadLevel ("lost");
		}
    }
    IEnumerator  fire()
    {
		sheepToFire.GetComponent<Renderer> ().enabled = false;
        p = nextAmmo.ammo[0];
		loadSheep.hasSheep = false;


        anim.SetBool("Fired", true);
        StartCoroutine(fireAnim());
        
        if (p != null)
        {


            nextAmmo.ammo[0] = null; // to initialize reload
		
		
			if (pause == false) {
				yield return new WaitForSeconds (0.5f);
			}

            if (p.tag == bullet_spirit.tag)
            {
                if(doubleShotActive == true)
                {
					Instantiate(bullet, new Vector2(-32f, -6f), Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                    anim.SetBool("Fired", true);
                    StartCoroutine(fireAnim());

                    
                }
				Instantiate(bullet, new Vector2(-32f, -6f), Quaternion.identity);
            }
            if (p.tag == bullet2_spirit.tag)
            {
                sheepExplodeGo = true;
                if (doubleShotActive == true)
                {
					Instantiate(bullet2, new Vector2(-32f, -6f), Quaternion.identity);

                    anim.SetBool("Fired", true);
                    yield return new WaitForSeconds(0.5f);
                    StartCoroutine(fireAnim());
                    
                }
                
				Instantiate(bullet2, new Vector2(-32f, -6f), Quaternion.identity);

            }
            if (p.tag == bullet3_spirit.tag)
            {
                if (doubleShotActive == true)
                {
					Instantiate(bullet3, new Vector2(-32f, -6f), Quaternion.identity);
                   
                    anim.SetBool("Fired", true);
                    yield return new WaitForSeconds(0.5f);
                    StartCoroutine(fireAnim());
                   
                } 
                
				Instantiate(bullet3, new Vector2(-32f, -6f), Quaternion.identity);
            }
			if (p.tag == bullet4_spirit.tag)
			{
				

				Instantiate(bullet4, new Vector2(-32f, -6f), Quaternion.identity);
			}
            
        }
        doubleShotActive = false;
		active = true;
    }
    private void lasoFire()
    {   
        if(lasoGo == true)
			Instantiate(laso, new Vector2(-32f, -7f), Quaternion.LookRotation(new Vector3(targetLaso.x,targetLaso.y)));
        
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
