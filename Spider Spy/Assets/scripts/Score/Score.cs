using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int _score;
	private GameObject _player;

	void Start()
	{
		_score = 0;
		_player = GameObject.FindGameObjectWithTag ("Player");

	}

	public void UpScore()
	{
		if(_player.GetComponent<CheckCollision>().alive())
			_score++;
	}

	public void SaveScore()
	{
		int HighScore = PlayerPrefs.GetInt("highscore");
		if (_score > HighScore)
			PlayerPrefs.SetInt ("highscore", _score);
	}
}