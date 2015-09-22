using UnityEngine;
using System.Collections;

public class OnStop : MonoBehaviour {
    public GameObject GameController;

    private GameObject Player;
    private bool playerIsAlive;

    void OnApplicationPause(bool pauseState)
	{
        Player = GameObject.FindGameObjectWithTag("Player");
        playerIsAlive = Player.GetComponent<CheckCollision>().alive();

        if (pauseState == true && playerIsAlive) {
           GameController = GameObject.FindGameObjectWithTag("GameController");
            GameController.GetComponent<GameplayControls>().Pause();
        }
    }
}
