using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreExibition : MonoBehaviour {
	private Score _Score;
	private Text _text;
	// Use this for initialization
	void Start () {
		_Score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
		_text = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		_text.text =  _Score._score.ToString() + " Pastas";
	}
}
