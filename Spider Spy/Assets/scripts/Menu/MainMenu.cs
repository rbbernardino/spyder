using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void Play()
	{
        Application.LoadLevel("Gameplay");
        //StartCoroutine (GoPlay ());
    }

	public void Credits()
	{
		//Application.LoadLevel ("Credits");
	}

	IEnumerator GoPlay()
	{
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ().SetBool ("Play", true);
		yield return new WaitForSeconds (2.5f);
		Application.LoadLevel ("Gameplay");
	}
}
