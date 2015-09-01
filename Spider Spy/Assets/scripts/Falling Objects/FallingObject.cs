	using UnityEngine;

public class FallingObject : MonoBehaviour
{
	private float speed;
	private GameObject _controller;

	// Use this for initialization
	void Start()
	{
		_controller = GameObject.FindGameObjectWithTag ("GameController");
		speed = _controller.GetComponent<Settings> ().FallingObjectSpeed;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
	}

	void  Update(){
		if (transform.position.y < -10) {
			Destroy(gameObject);
		}
	}
}