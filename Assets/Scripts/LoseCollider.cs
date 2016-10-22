using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	public static int lives =5;
	private Ball ball;
	private Paddle paddle;
	private Vector3  ballToPaddle= new Vector3 (0f,0.36f,0f);
	private bool hasStarted = true;
	public Text text;

	void OnCollisionEnter2D (Collision2D collision) {
		lives--;
		text.text = lives.ToString ();
		if (lives <= 0) {
			levelManager = GameObject.FindObjectOfType<LevelManager> ();
			levelManager.LoadLevel ("Lose");
		} else {
			ball = GameObject.FindObjectOfType<Ball>();
			paddle = GameObject.FindObjectOfType<Paddle>();

			hasStarted = false;
			Update ();
		}
	}

	void Update () {
		text.text = lives.ToString ();
		if (!hasStarted) {
			ball.transform.position = paddle.transform.position + ballToPaddle;
			
			if (Input.GetMouseButtonDown(0)) {
				print ("MOUSE CLICKED, LAUNCHING BALL!");
				hasStarted = true;
				ball.GetComponent<Rigidbody2D>().velocity = new Vector2 (Random.Range(-3f,3f),Random.Range (8f,12f));
			}
		}
	}
}
