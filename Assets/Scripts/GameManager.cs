using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {
	[SerializeField] private Paddle paddle;
	[SerializeField] private Ball ball;
	[SerializeField] private GameObject boundary;
	void Start () {
		//handles paddles and ball instantiation
		ball = Instantiate (ball);
		Paddle p1 = Instantiate (paddle);
		Paddle p2 = Instantiate (paddle);
		p1.gameObject.name = "P1";
		p2.gameObject.name = "P2";

		p1.placePaddle (true);
		p2.placePaddle (false);

		//handles boundary placement for game
		GameObject lowerBound = Instantiate(boundary);
		GameObject upperBound = Instantiate (boundary);
		lowerBound.gameObject.name = "Lower Bound";
		upperBound.gameObject.name = "Upper Bound";

		lowerBound.transform.position = new Vector2(0,-boundary.transform.position.y);
	}
	void Update(){
		if (Input.GetKeyDown ("escape")) {
			pause();
		}
	}
	void pause(){//handles pausing the game
		if (Time.timeScale == 1)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
	public void goToWinScreen(){//transitions to winscreen
		SceneManager.LoadScene (1);
	}
}
