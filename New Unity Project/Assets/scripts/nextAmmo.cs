using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class nextAmmo : MonoBehaviour {

    public static Queue<GameObject> cartrodge = new Queue<GameObject>();  //cartridge for bullets

    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
	public GameObject bullet4;

    public static int countAmmo;
    public static int score = 0;

    public Text ammoCountText; // GUI text for ammo count
    public Text scoreText; // GUI text for score
	public Text Life; // GUI text for life
    // Use this for initialization
    public static GameObject[] ammo = new GameObject[4]; // array of "spirit" objects that player will see
	void Start () {
        //load ammo
        for (int i = 0; i < 10; i++)
        {
            cartrodge.Enqueue(bullet2);
			cartrodge.Enqueue(bullet);
          // cartrodge.Enqueue(bullet4);
			cartrodge.Enqueue(bullet);
            //cartrodge.Enqueue(bullet3);
        }
        countAmmo = cartrodge.Count;
        ammoCountText.text = "Ammo : " + countAmmo;
        scoreText.text = "Score : " + score;
    }
	
	// Update is called once per frame
	void Update () {
        //if player fired once , then will start reload
        if (ammo[0] == null)
        {
            //if theres ammo to load
            if (cartrodge.Count > 0)
            {
                ammo[3] = cartrodge.Dequeue();

                ammo[3] = Instantiate(ammo[3], new Vector2(-22, -7), Quaternion.identity)as GameObject;
            }
           //move forward array + jump object
            for (int i = 0; i < 3; i++)
            { 
                if (ammo[i] != null)
                {
                    ammo[i].GetComponent<Rigidbody2D>().AddForce(new Vector2( -200,  150));
                   
                }
                ammo[i] = ammo[i + 1];
            }
            ammo[3] = null;       
        }
        countAmmo = cartrodge.Count;
        for (int i = 0; i < 3; i++) // add ammo from array
        {
            if(ammo[i] != null)
            {
                countAmmo ++;
            }
        }
        ammoCountText.text = "Ammo : " + countAmmo;
        scoreText.text = "Score : " + score;
		Life.text = "Life : " + GameManager.life;
    }
   
}
