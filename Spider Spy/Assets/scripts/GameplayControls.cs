using UnityEngine;
using System.Collections;

public class GameplayControls : MonoBehaviour {
    [SerializeField] private GameObject btPause;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuGameOver;

    private GameObject Player;
    private SoundControls soundControls;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        soundControls = GameObject.FindGameObjectWithTag("SoundsController").GetComponent<SoundControls>();
        menuPause.SetActive(false);
        menuGameOver.SetActive(false);
    }

    public void ShowGameover()
    {
        menuGameOver.SetActive(true);
        btPause.SetActive(false);
    }
    public void HideGameover() { menuGameOver.SetActive(false); }

    public void ShowPauseMenu()
    {
        menuPause.SetActive(true);
        btPause.SetActive(false);
    }
    public void HidePauseMenu()
    {
        btPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void HidePlayer() { Player.SetActive(false); }

    public void ResetGame()
    {
        soundControls.PlayButton();
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        soundControls.PlayButton();
        Application.LoadLevel("MenuPrincipal");
        Time.timeScale = 1;
    }

    public void Pause()
    {
        //Set time.timescale to 0, this will cause animations and physics to stop updating
        Time.timeScale = 0;
        //Show pause menu
        ShowPauseMenu();
        soundControls.StopClimbingSound();
    }

    public void Resume()
    {
        HidePauseMenu();
        Time.timeScale = 1;
        soundControls.PlayClimbingSound();
    }
}
