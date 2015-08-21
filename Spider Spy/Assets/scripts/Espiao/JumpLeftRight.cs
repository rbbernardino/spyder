using UnityEngine;
using System.Collections;

public class JumpLeftRight : MonoBehaviour {
	[SerializeField] private float moveForce = 5f;
	[SerializeField] private float leftLimitX = -1.53f;
	[SerializeField] private float rightLimitX = 1.45f;

	private bool movingLeft = false;
	private bool movingRight = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float currentPositionX = transform.position.x;
		if (Input.GetKeyDown ("space") && !movingLeft && !movingRight && currentPositionX > leftLimitX) {
			gameObject.GetComponent<AudioSource>().Play ();
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((-1f)*moveForce, 0);
			movingLeft = true;
			gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		}
		if (transform.position.x <= leftLimitX && movingLeft == true)
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			gameObject.transform.position = new Vector2(leftLimitX, gameObject.transform.position.y);
			movingLeft = false;
			gameObject.GetComponent<ParticleSystem>().enableEmission = true;
		}

		if (Input.GetKeyDown ("space") && !movingRight && !movingLeft && currentPositionX < rightLimitX) {
			gameObject.GetComponent<AudioSource>().Play ();
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveForce, 0);
			movingRight = true;
			gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		}
		if (transform.position.x >= rightLimitX && movingRight == true)
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			gameObject.transform.position = new Vector2(rightLimitX, gameObject.transform.position.y);
			movingRight = false;
			gameObject.GetComponent<ParticleSystem>().enableEmission = true;
		}
	}
}
