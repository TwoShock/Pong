using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	void Start () {
		GameObject.Find("victory_text").GetComponent<Text>().text = "PLAYER "+PlayerPrefs.GetInt("winner")+ " WINS !";
	}
	void Update(){
		if (Input.GetKey ("space")) {
			SceneManager.LoadScene (0);
		}
	}
}
