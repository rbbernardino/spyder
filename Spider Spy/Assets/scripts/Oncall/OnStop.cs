using UnityEngine;
using System.Collections;

public class OnStop : MonoBehaviour {
    public GameObject Controller;

    void OnApplicationPause(bool pauseState)
	{
		if (pauseState == true) {
            Controller.GetComponent<GameplayControls>().Pause();
        }
    }
}
