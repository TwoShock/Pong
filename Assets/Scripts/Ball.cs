using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	private Rigidbody2D rb;
	[SerializeField] private float speed;//stores balls speed
	private int p1Score;//stores player 1's score
	private int p2Score;
	void Start () {//intializes score to zeros
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2(1,-1) * speed;
		p1Score = 0;
		p2Score = 0;
	}
	float hitFactor(Vector2 ballPos,Vector2 paddlePos,float paddleHeight){//computes where the ball hit the paddle
		return (ballPos.y - paddlePos.y) / paddleHeight;
	}
	void OnCollisionEnter2D(Collision2D other){//handles ball collision with paddle
		if (other.gameObject.name == "P1") {
			float yDir = hitFactor (transform.position,other.transform.position,other.collider.bounds.size.y);
			Vector2 dir = new Vector2 (-1,yDir).normalized;
			rb.velocity = dir * speed;
		} 
		else if (other.gameObject.name == "P2") {
			float yDir = hitFactor (transform.position,other.transform.position,other.collider.bounds.size.y);
			Vector2 dir = new Vector2 (1, yDir).normalized;
			rb.velocity = dir * speed;
		}
	}
	void FixedUpdate(){//checks if ball is out of map and resets ball position and intial ball angle
		if (transform.position.x >= 9f || transform.position.x <= -9f) {
			rb.velocity = Vector2.zero;
			transform.position = Vector2.zero;
			int random = Random.Range (0, 2);
			if (random == 0)
				rb.velocity = new Vector2 (1, -1) * speed;
			else
				rb.velocity = new Vector2 (-1, -1) * speed;
		}	
	}
	void OnTriggerEnter2D(Collider2D other){//checks if the ball collides on left half or righ half and updates score
		if (other.tag == "Left Wall") {
			p1Score++;
			
		} 
		else if (other.tag == "Right Wall") {
			p2Score++;
		}
		GameObject.Find("Score").GetComponent<Text>().text = p2Score + "   " + p1Score;
		if (p1Score == 10 || p2Score == 10) {//if a player reaches max score reset scores and display winner
			GameObject.Find ("GameManager").GetComponent<GameManager> ().goToWinScreen ();
			int winner = (p1Score - p2Score > 0) ? 1 : 2;
			PlayerPrefs.SetInt("winner",winner);
			p1Score = 0;
			p2Score = 0;
		}

	}
}
