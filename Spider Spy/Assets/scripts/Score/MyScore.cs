using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MyScore : MonoBehaviour {
	private Text _text;
	private Score _Score;
	// Use this for initialization
	void OnEnable () {
		_Score = GameObject.FindGameObjectWithTag ("Score").GetComponent<Score> ();
		_text = gameObject.GetComponent<Text> ();
//		gameObject.GetComponent<Canvas>().sortingLayerName = "Buttons";
		_text.text =  _Score._score.ToString() ;
	}

}
