using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	[SerializeField] private float speed;//stores paddle speed
	private Rigidbody2D rb;
	private string axis;//stores player control inputs
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	public void placePaddle(bool right){//handles control assignment and paddle positioning
		Vector2 pos = Vector2.zero;
		if (right) {
			pos = new Vector2 (8.75f,0);
			axis = "Vertical";
		} 
		else {
			pos = new Vector2 (-8.75f, 0);
			axis = "Vertical2";
		}
		transform.position = pos;
	}
	void FixedUpdate(){//handles paddle movement
		float dir = Input.GetAxisRaw (axis);
		rb.velocity = new Vector2 (0, dir)*speed;
	}
}
