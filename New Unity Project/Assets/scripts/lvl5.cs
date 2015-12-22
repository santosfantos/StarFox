using UnityEngine;
using System.Collections;

public class lvl5 : MonoBehaviour {
	private float random1;
	private float random2;
	public GameObject sheep;

	public GameObject wolf;
	void Start () {
		WolfBehaviourScript1.y1 = Random.Range(8f, 11F);
		GameManager.wolfcounter = 0;
		StartCoroutine(createObjectlvl5());
	}
	IEnumerator createObjectlvl5()
	{
		random1 = Random.Range (2f, 9F);
		random2 = Random.Range (2f, 9F);
		for( int i = 0 ; i < 20 ; i ++){

			if(i % 3 == 0 ){
				Instantiate (sheep, new Vector2 (32,random1), Quaternion.identity);
				yield return new WaitForSeconds (4);
			}

			Instantiate(wolf, new Vector2(32 ,random2), Quaternion.identity) ; 
			yield return new WaitForSeconds(2);
		}





	}
	// Update is called once per frame
	void Update () {
		if (GameManager.wolfcounter == 20) {
			Application.LoadLevel ("level 6");
		}
	}
}
