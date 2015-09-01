using UnityEngine;
using System.Collections;

public class MovePrediosEsq : MonoBehaviour {
	[SerializeField] private float initialVelocityY;
	[SerializeField] private float restartPositionY;
	[SerializeField] private float endPositionY;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, initialVelocityY);
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (transform.position.y <= endPositionY)
		{
			transform.position = new Vector2(transform.position.x, restartPositionY);
		}
	}
}