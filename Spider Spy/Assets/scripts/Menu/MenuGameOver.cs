using UnityEngine;
using System.Collections;

public class MenuGameOver : MonoBehaviour {

	public void Reset()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Menu()
	{
		Application.LoadLevel ("MenuPrincipal");
	}
}
