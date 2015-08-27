using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    [SerializeField]
    private GameObject ButtonSound;

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
        ButtonSound.GetComponent<AudioSource>().Play();
        GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ().SetBool ("Play", true);
		yield return new WaitForSeconds (2.5f);
		Application.LoadLevel ("Gameplay");
	}
}
