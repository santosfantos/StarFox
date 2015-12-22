using UnityEngine;
using System.Collections;

public class lvl1 : MonoBehaviour {

	public GameObject sheep;

	public GameObject Wolf;


	void Start () {
		Wolf.GetComponentInChildren<ParticleSystem>().enableEmission = false; 
		WolfBehaviourScript1.y1 = Random.Range(4f, 7F);
		StartCoroutine(createObjectlvl1());
	}
	IEnumerator createObjectlvl1()
	{

		for( int i = 0 ; i < 10 ; i ++){
			
			if(i % 2 == 0 ){
				Instantiate (sheep, new Vector2 (32,9), Quaternion.identity);
				yield return new WaitForSeconds (3);
			}

			Instantiate(Wolf, new Vector2(32 ,5), Quaternion.identity) ;

			yield return new WaitForSeconds(1);
		}





	}
	// Update is called once per frame
	void Update () {
		
		if (GameManager.wolfcounter == 10) {
			Application.LoadLevel ("level 2");
		}
	}
}
