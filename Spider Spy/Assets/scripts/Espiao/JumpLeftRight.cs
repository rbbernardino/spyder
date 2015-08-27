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

    private SoundControls soundControls;

	private bool movingLeft = false;
	private bool movingRight = false;

	// Use this for initialization
	void Start () {
        soundControls = GameObject.FindGameObjectWithTag("SoundsController").GetComponent<SoundControls>();

        PlayerClimbLeft.SetActive (true);
		ActivePlayer = PlayerClimbLeft;
        soundControls.PlayClimbingSound();
	}
	
	// Update is called once per frame
	void Update () {
		float currentPositionX = transform.position.x;

		// jump left
		if ((Input.GetKeyDown ("space") || TouchedScreen()) && !movingLeft && !movingRight && currentPositionX > leftLimitX) {
			soundControls.PlayJump();
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
            // ajusta posicao do Player
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			gameObject.transform.position = new Vector2(leftLimitX, gameObject.transform.position.y);

            // sinaliza final de pulo
            movingLeft = false;

            // troca sprint para subindo
			ActivePlayer.SetActive(false);
			PlayerClimbLeft.SetActive(true);
			ActivePlayer = PlayerClimbLeft;

            // invert x position of RunEffectContainer animation
            RunEffectContainer.transform.position = new Vector2(0, RunEffectContainer.transform.position.y);

            // inicia som de subida
            soundControls.PlayClimbingSound();
        }

        // jump right
        if ((Input.GetKeyDown ("space") || TouchedScreen()) && !movingRight && !movingLeft && currentPositionX < rightLimitX) {
            // para som de subida
            soundControls.StopClimbingSound();

            gameObject.GetComponent<AudioSource>().Play ();
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveForce, 0);
			movingRight = true;

			ActivePlayer.SetActive(false);
			PlayerJumpRight.SetActive(true);
			ActivePlayer = PlayerJumpRight;

            soundControls.StopClimbingSound();
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

            // inicia som de subida
            soundControls.PlayClimbingSound();
        }
    }

    private static bool TouchedScreen() {
        if (Input.touchCount > 0)
            return Input.GetTouch(0).phase == TouchPhase.Began;
        else
            return false;
    }
}
