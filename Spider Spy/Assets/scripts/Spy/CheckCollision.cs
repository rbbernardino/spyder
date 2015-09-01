using UnityEngine;

public class CheckCollision : MonoBehaviour
{
	private bool isAlive;
	private Score score;
    private GameplayControls gameplayControls;
    private SoundControls soundControls;

	public bool alive(){return isAlive;}
	void Start(){	
		isAlive = true;
		score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
        gameplayControls = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayControls>();
        soundControls = GameObject.FindGameObjectWithTag("SoundsController").GetComponent<SoundControls>();
    }

    // Die by collision
    // Collider is on child objects
    void OnTriggerEnter2D(Collider2D other){
		string tag = other.gameObject.tag;
		switch (tag) {
            case ("Item"):
                score.UpScore();
                soundControls.PlayIntemCatch();
                Destroy(other.gameObject);
                break;
		    case ("Bomb"):
                soundControls.PlayBombExplosion();
                Destroy(other.gameObject);
                Die();
			    break;
        }
	}
	
	void Die()
	{
        soundControls.StopClimbingSound();
        isAlive = false;
		SpecialEffectsHelper.Instance.Explosion (transform.position);
        score.SaveScore ();
        gameplayControls.ShowGameover();
        gameplayControls.HidePlayer();
	}
}
