using UnityEngine;
using System.Collections;

public class SetCanvasLayer : MonoBehaviour {

	[SerializeField] private string Layer;
	public void Start()
	{
		GetComponent<Canvas> ().sortingLayerName = Layer;
		
	}
}
