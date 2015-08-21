using UnityEngine;

public class CheckCollision : MonoBehaviour
{
	private GameObject _menuPopUP;
	private GameObject _player;
	private bool isAlive;
	private Score _score;

	public bool alive(){return isAlive;}
	void Start(){	
		isAlive = true;
		_menuPopUP = GameObject.FindGameObjectWithTag ("MenuGameOver");
		_player = GameObject.FindGameObjectWithTag ("Player");
		_score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
		_menuPopUP.SetActive (false);

	}

	// Die by collision
	// Collider is on child objects
	public void OnChildTriggerEnter(Collider2D other){
		string tag = other.gameObject.tag;
		switch (tag) {
		case ("Item"):
			_score.UpScore();
			GameObject.FindGameObjectWithTag("ItemCatch").GetComponent<AudioSource>().Play();
			Destroy(other.gameObject);
			break;
		case ("Bomb"):
			GameObject.FindGameObjectWithTag("BombExplosion").GetComponent<AudioSource>().Play();
			Die();
			break;
		}
	}
	
	void Die()
	{
		isAlive = false;
		SpecialEffectsHelper.Instance.Explosion (transform.position);
		//Application.LoadLevel(Application.loadedLevel);
		_player.SetActive(false);
		_score.SaveScore ();
		_menuPopUP.SetActive (true);
	}
}
