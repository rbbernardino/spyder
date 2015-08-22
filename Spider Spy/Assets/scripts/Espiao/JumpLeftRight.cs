using UnityEngine;
using System.Collections;

public class JumpLeftRight : MonoBehaviour {
	[SerializeField] private float moveForce = 5f;
	[SerializeField] private float leftLimitX = -1.53f;
	[SerializeField] private float rightLimitX = 1.45f;

	public GameObject PlayerClimbLeft;
	public GameObject PlayerClimbRight;
	public GameObject PlayerJumpLeft;
	public GameObject PlayerJumpRight;

    public GameObject RunEffectContainer;

    private GameObject ActivePlayer;

	private bool movingLeft = false;
	private bool movingRight = false;

	// Use this for initialization
	void Start () {
		PlayerClimbLeft.SetActive (true);
		ActivePlayer = PlayerClimbLeft;

	}
	
	// Update is called once per frame
	void Update () {
		float currentPositionX = transform.position.x;

		// jump left
		if (Input.GetKeyDown ("space") && !movingLeft && !movingRight && currentPositionX > leftLimitX) {
			gameObject.GetComponent<AudioSource>().Play ();
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((-1f)*moveForce, 0);
			movingLeft = true;

            // change to jumping left sprite
			ActivePlayer.SetActive(false);
			PlayerJumpLeft.SetActive(true);
			ActivePlayer = PlayerJumpLeft;
		}

		// Climb left
		if (transform.position.x <= leftLimitX && movingLeft == true)
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			gameObject.transform.position = new Vector2(leftLimitX, gameObject.transform.position.y);
			movingLeft = false;

			ActivePlayer.SetActive(false);
			PlayerClimbLeft.SetActive(true);
			ActivePlayer = PlayerClimbLeft;

            // invert x position of RunEffectContainer animation
            RunEffectContainer.transform.position = new Vector2(0, RunEffectContainer.transform.position.y);
        }

        // jump right
        if (Input.GetKeyDown ("space") && !movingRight && !movingLeft && currentPositionX < rightLimitX) {
			gameObject.GetComponent<AudioSource>().Play ();
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveForce, 0);
			movingRight = true;

			ActivePlayer.SetActive(false);
			PlayerJumpRight.SetActive(true);
			ActivePlayer = PlayerJumpRight;
        }

        // Climb right
        if (transform.position.x >= rightLimitX && movingRight == true)
		{
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			gameObject.transform.position = new Vector2(rightLimitX, gameObject.transform.position.y);
			movingRight = false;

			ActivePlayer.SetActive(false);
			PlayerClimbRight.SetActive(true);
			ActivePlayer = PlayerClimbRight;

            // invert x position of RunEffectContainer animation
            RunEffectContainer.transform.position = new Vector2(8.62f, RunEffectContainer.transform.position.y);
        }
    }
}
