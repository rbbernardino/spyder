using UnityEngine;

public class CheckCollision : MonoBehaviour
{
	private bool isAlive;
	private Score _score;
    private GameplayControls gameplayControls;

	public bool alive(){return isAlive;}
	void Start(){	
		isAlive = true;
		_score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
        gameplayControls = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayControls>();
    }

    // Die by collision
    // Collider is on child objects
    void OnTriggerEnter2D(Collider2D other){
		string tag = other.gameObject.tag;
		switch (tag) {
		case ("Item"):
			_score.UpScore();
			GameObject.FindGameObjectWithTag("ItemCatch").GetComponent<AudioSource>().Play();
			Destroy(other.gameObject);
			break;
		case ("Bomb"):
			GameObject.FindGameObjectWithTag("BombExplosion").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            Die();
			break;
		}
	}
	
	void Die()
	{
		isAlive = false;
		SpecialEffectsHelper.Instance.Explosion (transform.position);
        //Application.LoadLevel(Application.loadedLevel);
        _score.SaveScore ();
        gameplayControls.ShowGameover();
        gameplayControls.HidePlayer();
	}
}
