using UnityEngine;
using System.Collections;

public class lvl6 : MonoBehaviour {

	private float random1;
	private float random2;
	public GameObject sheep;

	public GameObject wolf;
	void Start () {
		WolfBehaviourScript1.y1 = Random.Range(9f, 12F);
		GameManager.wolfcounter = 0;
		StartCoroutine(createObjectlvl6());
	}
	IEnumerator createObjectlvl6()
	{
		
		for( int i = 0 ; i < 25 ; i ++){
			random1 = Random.Range (5f, 9F);
			random2 = Random.Range (3f, 9F);
			if(i % 4 == 0 ){
				Instantiate (sheep, new Vector2 (32,random1), Quaternion.identity);
				yield return new WaitForSeconds (2);
			}

			Instantiate(wolf, new Vector2(32 ,random2), Quaternion.identity) ; 
			yield return new WaitForSeconds(3);
		}





	}
	// Update is called once per frame
	void Update () {
		if (GameManager.wolfcounter == 25) {
			Application.LoadLevel ("level 7");
		}
	}
}
