using UnityEngine;
using System.Collections;

public class GameplayControls : MonoBehaviour {
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuGameOver;

    private GameObject Player;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        menuPause.SetActive(false);
        menuGameOver.SetActive(false);
    }

    public void ShowGameover() { menuGameOver.SetActive(true); }
    public void HideGameover() { menuGameOver.SetActive(false); }

    public void ShowPauseMenu() { menuPause.SetActive(true); }
    public void HidePauseMenu() { menuPause.SetActive(false); }

    public void HidePlayer() { Player.SetActive(false); }

    public void ResetGame() { Application.LoadLevel(Application.loadedLevel); }
    public void MainMenu() { Application.LoadLevel("MenuPrincipal"); }

    public void Pause()
    {
        //Set time.timescale to 0, this will cause animations and physics to stop updating
        Time.timeScale = 0;
        //Show pause menu
        menuPause.SetActive(true);
    }

    public void Resume()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1;
    }
}
