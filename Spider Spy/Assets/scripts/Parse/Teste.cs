using UnityEngine;
using System.Collections;
using Parse;
public class Teste : MonoBehaviour {
	// Use this for initialization
	void Start () {
		ParseObject gameScore = new ParseObject("GameScore");
		gameScore["Score"] = 10;
		gameScore["PlayerName"] = "Estaban";
		gameScore.SaveAsync();
    }
}
