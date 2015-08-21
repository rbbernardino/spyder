using UnityEngine;
using System.Collections;

public class RedirectCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		GameObject _player = GameObject.FindGameObjectWithTag ("Player");
		_player.GetComponent<CheckCollision> ().OnChildTriggerEnter (other);
	}
}
