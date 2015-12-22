using UnityEngine;
using System.Collections;

public class lvl4 : MonoBehaviour {
	private float random1;
	private float random2;
	public GameObject sheep;

	public GameObject wolf;
	void Start () {
		WolfBehaviourScript1.y1 = Random.Range(7f, 10F);
		GameManager.wolfcounter = 0;
		StartCoroutine(createObjectlvl4());
	}
	IEnumerator createObjectlvl4()
	{
		random1 = Random.Range (2f, 9F);
		random2 = Random.Range (2f, 9F);
		for( int i = 0 ; i < 16 ; i ++){
			

			if(i % 3 == 0 ){
				Instantiate (sheep, new Vector2 (32,random1), Quaternion.identity);
				yield return new WaitForSeconds (1);
			}

			Instantiate(wolf, new Vector2(32 ,random2), Quaternion.identity) ; 
			yield return new WaitForSeconds(1);
		}





	}
	// Update is called once per frame
	void Update () {
		if (GameManager.wolfcounter == 16) {
			Application.LoadLevel ("level 5");
		}
	}
}
