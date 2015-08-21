using UnityEngine;
using System.Collections;

public class MovePrediosDir : MonoBehaviour {
	[SerializeField] private float initialVelocityY = -10f;
	[SerializeField] private float restartPositionY = 11f;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, initialVelocityY);
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (transform.position.y < -10.63)
		{
		transform.position = new Vector2 (transform.position.x, restartPositionY);
		}
	}
}
