using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestScore : MonoBehaviour {
	private Text _text;
	private Score _Score;
	void OnEnable () {
		_Score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
		_text = gameObject.GetComponent<Text> ();
		int HighScore = PlayerPrefs.GetInt("highscore");
		if (_Score._score > HighScore) {
			_text.text =  _Score._score.ToString();
		} else {
			_text.text = PlayerPrefs.GetInt("highscore").ToString();
		}
	}
}
