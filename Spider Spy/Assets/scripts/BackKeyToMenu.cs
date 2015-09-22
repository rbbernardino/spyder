using UnityEngine;
using System.Collections;

public class BackKeyToMenu : MonoBehaviour {

    private GameObject GameController;

    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameController.GetComponent<GameplayControls>().MainMenu();
    }
}
