using UnityEngine;
using System.Collections;

public class GetRandomObject : MonoBehaviour {
	[SerializeField] private GameObject missle1;
	[SerializeField] private GameObject missle2;
	[SerializeField] private GameObject bomb;

	public GameObject GetRandomThreatObject() {
		float rdmNumber = Random.value;
		if (rdmNumber < 0.3)
			return missle1;
		else if (rdmNumber >= 0.3 && rdmNumber < 0.6)
			return missle2;
		else
			return bomb;
	}
}
