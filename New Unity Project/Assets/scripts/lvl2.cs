using UnityEngine;
using System.Collections;

public class lvl2 : MonoBehaviour {

	public GameObject sheep;

	public GameObject wolf;

	// Use this for initialization
	void Start () {
		WolfBehaviourScript1.y1 = Random.Range(5f, 8F);
		GameManager.wolfcounter = 0;
		StartCoroutine(createObjectlvl2());
	}
	IEnumerator createObjectlvl2()
	{

		for( int i = 0 ; i < 14 ; i ++){

			if(i % 2 == 1 ){
				Instantiate (sheep, new Vector2 (32,9), Quaternion.identity);
				yield return new WaitForSeconds (2);
			}

			Instantiate(wolf, new Vector2(32 ,5), Quaternion.identity) ; 
			yield return new WaitForSeconds(1);
		}





	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.wolfcounter == 14) {
			Application.LoadLevel ("level 3");
		}
	}
}
