using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown(0)) {
				print ("MOUSE CLICKED, LAUNCHING BALL!");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (Random.Range(-3f,3f),Random.Range (8f,12f));
			}
		}
	}

	void OnCollissionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range (-2f,2f),Random.Range (-2f,2f));
		if (hasStarted) {
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
