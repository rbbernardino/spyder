	using UnityEngine;

public class FallingObject : MonoBehaviour
{
	public Vector2 speed = new Vector2(0, -10);
	// Use this for initialization
	void Start()
	{
		GetComponent<Rigidbody2D>().velocity = speed;
	}

	void  Update(){
		if (transform.position.y < -10) {
			Destroy(gameObject);
		}
	}
}