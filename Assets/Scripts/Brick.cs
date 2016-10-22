using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack; 
	private int timesHit;
	public GameObject smoke;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private bool isBreakable;

	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
			levelManager.BrickDestroyed ();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError ("Brick Sprite missing!");
		}
	}
	
}
