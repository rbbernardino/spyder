using UnityEngine;
using System.Collections;

public class GameplayControls : MonoBehaviour {
    [SerializeField] private GameObject btPause;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject tutorial;

    private GameObject Player;
    private GameObject PlayerContainer;
    private SoundControls soundControls;

    private bool isFirstTime;

    private bool onTutorial;

    void Awake()
    {
        Application.runInBackground = false;
    }

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerContainer = GameObject.FindGameObjectWithTag("PlayerContainer");
        soundControls = GameObject.FindGameObjectWithTag("SoundsController").GetComponent<SoundControls>();
        menuPause.SetActive(false);
        menuGameOver.SetActive(false);
        tutorial.SetActive(false);

        if (!PlayerPrefs.HasKey ("firstTime")) {
			PlayerPrefs.SetString ("firstTime", "true");
		}
        isFirstTime = bool.Parse(PlayerPrefs.GetString("firstTime"));
        if (isFirstTime) {
			DoTutorial ();
		}
    }

    public void Update()
    {
        if(onTutorial && (Input.GetKeyDown("space") || TouchedScreen()))
        {
            onTutorial = false;
            tutorial.SetActive(false);
            Time.timeScale = 1;
            isFirstTime = false;
            PlayerPrefs.SetString("firstTime", isFirstTime.ToString());
        }
    }

    private void DoTutorial()
    {
        onTutorial = true;
        Time.timeScale = 0;
        tutorial.SetActive(true);
    }

    public void ShowGameover()
    {
        menuGameOver.SetActive(true);
        btPause.SetActive(false);
    }
    public void HideGameover() { menuGameOver.SetActive(false); }

    public void ShowPauseMenu()
    {
        if (Player.GetComponent<CheckCollision>().alive())
        {
            menuPause.SetActive(true);
            btPause.SetActive(false);
        }
    }
    public void HidePauseMenu()
    {
        btPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void HidePlayer()
    {
        Player.SetActive(false);
        PlayerContainer.SetActive(false);
    }

    public void ResetGame()
    {
        soundControls.PlayButton();
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1;
        soundControls.PlayButton();
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

    private static bool TouchedScreen()
    {
        if (Input.touchCount > 0)
            return Input.GetTouch(0).phase == TouchPhase.Began;
        else
            return false;
    }

}
