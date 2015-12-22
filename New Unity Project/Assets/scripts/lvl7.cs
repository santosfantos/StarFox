using UnityEngine;
using System.Collections;

public class lvl7 : MonoBehaviour {

	private float random1;
	private float random2;
	public GameObject sheep;

	public GameObject wolf;
	void Start () {
		WolfBehaviourScript1.y1 = Random.Range(10f, 14F);
		GameManager.wolfcounter = 0;
		StartCoroutine(createObjectlvl7());
	}
	IEnumerator createObjectlvl7()
	{
		
		for( int i = 0 ; i < 30 ; i ++){
			random1 = Random.Range (3f, 5F);
			random2 = Random.Range (2f, 9F);
			if(i % 5 == 0 ){
				Instantiate (sheep, new Vector2 (32,random1), Quaternion.identity);
				yield return new WaitForSeconds (4);
			}

			Instantiate(wolf, new Vector2(32 ,random2), Quaternion.identity) ; 
			yield return new WaitForSeconds(2);
		}





	}
	// Update is called once per frame
	void Update () {
		if (GameManager.wolfcounter == 30) {
			Application.LoadLevel ("level 8");
		}
	}
}
