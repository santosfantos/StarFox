using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class openSceneController : MonoBehaviour {
	public Button button;
	void start(){
		
		button.GetComponent<Text>().text = "Start";
	}
	public void buttonOnClick(){
		Application.LoadLevel ("sheepwolf");
	}
}
