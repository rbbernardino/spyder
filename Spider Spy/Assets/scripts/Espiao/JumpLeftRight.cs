using UnityEngine;
using System.Collections;

public class JumpLeftRight : MonoBehaviour {
	[SerializeField] private float moveForce = 5f;
	[SerializeField] private float leftLimitX = -1.53f;
	[SerializeField] private float rightLimitX = 1.45f;

    public GameObject RunEffectContainer;

    private GameObject Spy;
    private Animator SpyAnimator;

    private SoundControls soundControls;

	private bool movingLeft = false;
	private bool movingRight = false;

	// Use this for initialization
	void Start () {
        soundControls = GameObject.FindGameObjectWithTag("SoundsController").GetComponent<SoundControls>();
        Spy = GameObject.FindGameObjectWithTag("Player");
        SpyAnimator = Spy.GetComponent <Animator> ();

        soundControls.PlayClimbingSound();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float currentPositionX = transform.position.x;

		// jump to the left
		if ((Input.GetKeyDown ("space") || TouchedScreen()) && !movingLeft && !movingRight && currentPositionX > leftLimitX) {
			soundControls.PlayJump();

            // start to move left
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2((-1f)*moveForce, 0);
			movingLeft = true;

            // change to jumping left sprite
            SpyAnimator.SetTrigger("Jumping");
            SpyAnimator.ResetTrigger("Climbing");
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

		// Climb left
		if (transform.position.x <= leftLimitX && movingLeft == true)
		{
            // ajusta posicao do Player
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			gameObject.transform.position = new Vector2(leftLimitX, gameObject.transform.position.y);

            // sinaliza final de pulo
            movingLeft = false;

            // change to climbing left sprite
            SpyAnimator.SetTrigger("Climbing");
            SpyAnimator.ResetTrigger("Jumping");

            // invert x position of RunEffectContainer animation
            RunEffectContainer.transform.position = new Vector2(0, RunEffectContainer.transform.position.y);

            // inicia som de subida
            soundControls.PlayClimbingSound();
        }

        // jump to right
        if ((Input.GetKeyDown ("space") || TouchedScreen()) && !movingRight && !movingLeft && currentPositionX < rightLimitX) {
            // change to jumping left sprite
            SpyAnimator.SetTrigger("Jumping");
            SpyAnimator.ResetTrigger("Climbing");
            transform.eulerAngles = new Vector3(0, 180, 0);

            // para som de subida
            soundControls.StopClimbingSound();

            gameObject.GetComponent<AudioSource>().Play ();
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveForce, 0);
			movingRight = true;

            soundControls.StopClimbingSound();
        }

        // Climb right
        if (transform.position.x >= rightLimitX && movingRight == true)
		{
            // change to climbing right sprite
            SpyAnimator.SetTrigger("Climbing");
            SpyAnimator.ResetTrigger("Jumping");

            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			gameObject.transform.position = new Vector2(rightLimitX, gameObject.transform.position.y);
			movingRight = false;

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
