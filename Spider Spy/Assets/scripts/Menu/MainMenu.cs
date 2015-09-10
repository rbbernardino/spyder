using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [SerializeField] private GameObject ButtonSound;
    [SerializeField] private GameObject MusicSound;


    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsScreen;

    [SerializeField] private AudioMixerSnapshot muteMusic;
    [SerializeField] private AudioMixerSnapshot muteSoundFx;
    [SerializeField] private AudioMixerSnapshot muteAllSounds;
    [SerializeField] private AudioMixerSnapshot allSoundsOn;

    [SerializeField] private Toggle toogleMusic;
    [SerializeField] private Toggle toogleSoundFx;

    private bool isFirstTime;
    private bool isMusicOn;
    private bool isSoundFxOn;

    void Awake()
    {
        Application.runInBackground = false;

        if (!PlayerPrefs.HasKey("firstTime"))
            PlayerPrefs.SetString("firstTime", "true");
        isFirstTime = bool.Parse(PlayerPrefs.GetString("firstTime"));

        if (isFirstTime)
        {
            PlayerPrefs.SetString("music", "true");
            PlayerPrefs.SetString("soundFx", "true");
        }

        // load user sounds preferences
        isMusicOn = bool.Parse(PlayerPrefs.GetString("music"));
        isSoundFxOn = bool.Parse(PlayerPrefs.GetString("soundFx"));
        UpdateSoundsVolume();
    }

    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsScreen.SetActive(false);

        // Play independently of on or off, if volume is down no sound will be output
        MusicSound.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// User Interface Functions
    /// </summary>
    public void Play()
    {
        int loadedLevel = Application.loadedLevel;
        Application.LoadLevelAsync(loadedLevel + 1);
    }

    public void OpenSettings()
    {
        HideMainMenu();
        ShowSettingsMenu();
    }

    public void OpenCredits()
    {
        HideMainMenu();
        ShowCreditsScreen();
    }

    public void ReturnToMainMenu()
    {
        HideCreditsScreen();
        HideSettingsMenu();
        ShowMainMenu();
    }

    public void PlayButtonSound()
    {
        ButtonSound.GetComponent<AudioSource>().Play();
    }

    public void ToogleMusic(bool musicToggle)
    {
        PlayerPrefs.SetString("music", musicToggle.ToString());
        isMusicOn = musicToggle;
        UpdateSoundsVolume();
    }

    public void ToogleSoundFx(bool soundFxToggle)
    {
        PlayerPrefs.SetString("soundFx", soundFxToggle.ToString());
        isSoundFxOn = soundFxToggle;
        UpdateSoundsVolume();
    }

    /// <summary>
    /// Menus, Screens, etc. Hide/Show functions
    /// </summary>
    private void ShowSettingsMenu() { settingsMenu.SetActive(true); }
    private void HideSettingsMenu() { settingsMenu.SetActive(false); }
    private void ShowCreditsScreen() { creditsScreen.SetActive(true); }
    private void HideCreditsScreen() { creditsScreen.SetActive(false); }
    private void ShowMainMenu() { mainMenu.SetActive(true); }
    private void HideMainMenu() { mainMenu.SetActive(false); }

    private static bool TouchedScreen()
    {
        if (Input.touchCount > 0)
            return Input.GetTouch(0).phase == TouchPhase.Began;
        else
            return false;
    }

    private void UpdateSoundsVolume()
    {
        toogleMusic.isOn = isMusicOn;
        toogleSoundFx.isOn = isSoundFxOn;
        float fadeTime = 0f;
        if ( isMusicOn &&  isSoundFxOn) allSoundsOn.   TransitionTo(fadeTime);
        if (!isMusicOn && !isSoundFxOn) muteAllSounds. TransitionTo(fadeTime);
        if (!isMusicOn &&  isSoundFxOn) muteMusic.     TransitionTo(fadeTime);
        if ( isMusicOn && !isSoundFxOn) muteSoundFx.   TransitionTo(fadeTime);
    }
}
