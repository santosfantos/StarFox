using UnityEngine;
using System.Collections;

public class lvl8 : MonoBehaviour {

	private float random1;
	private float random2;
	public GameObject sheep;

	public GameObject wolf;
	void Start () {
		WolfBehaviourScript1.y1 = Random.Range(11f, 15F);
		GameManager.wolfcounter = 0;
		StartCoroutine(createObjectlvl8());
	}
	IEnumerator createObjectlvl8()
	{
		
		for( int i = 0 ; i < 40 ; i ++){
			random1 = Random.Range (3f, 7F);
			random2 = Random.Range (2f, 9F);
			if(i % 6 == 0 ){
				Instantiate (sheep, new Vector2 (32,random1), Quaternion.identity);
				yield return new WaitForSeconds (5);
			}

			Instantiate(wolf, new Vector2(32 ,random2), Quaternion.identity) ; 
			yield return new WaitForSeconds(1);
		}





	}

	// Update is called once per frame
	void Update () {
		if (GameManager.wolfcounter == 40) {
			Application.LoadLevel ("finish");
		}
	}
}
