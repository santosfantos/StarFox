using UnityEngine;
using System.Collections;

public class lvl3 : MonoBehaviour {
	public GameObject sheep;

	public GameObject wolf;

	void Start () {
		WolfBehaviourScript1.y1 = Random.Range(6f, 9F);
		GameManager.wolfcounter = 0;
		StartCoroutine(createObjectlvl3());
	}
	IEnumerator createObjectlvl3()
	{

		for( int i = 0 ; i < 16 ; i ++){
			
			if(i % 3 == 0 ){
				Instantiate (sheep, new Vector2 (32,9), Quaternion.identity);
				yield return new WaitForSeconds (1);
			}

			Instantiate(wolf, new Vector2(32 ,5), Quaternion.identity) ; 
			yield return new WaitForSeconds(1);
		}





	}
	// Update is called once per frame
	void Update () {
		if (GameManager.wolfcounter == 16) {
			Application.LoadLevel ("level 4");
		}
	}
}
