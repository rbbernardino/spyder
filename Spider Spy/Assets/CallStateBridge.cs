using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class CallStateBridge : MonoBehaviour {
    [SerializeField] private AudioMixerSnapshot muteMusic;
    [SerializeField] private AudioMixerSnapshot muteSoundFx;
    [SerializeField] private AudioMixerSnapshot muteAllSounds;
    [SerializeField] private AudioMixerSnapshot allSoundsOn;

    private bool musicOn;
    private bool soundFxOn;

#if UNITY_ANDROID
    AndroidJavaObject jc;
     #endif
 
     void Start ()
     {
         #if UNITY_ANDROID
             AndroidJNI.AttachCurrentThread();
             jc = new AndroidJavaClass("com.android.plava.spiderspy.CallStatusBridge");
             jc.CallStatic("setCallBack", new object[2] {gameObject.name, "OnCallStateChange"});
         #endif
     }
 
     // 0 - idle (sem ligacao)
     // 1 - ringing - chamando
     // 2 - offhook - atendeu
     public void OnCallStateChange(string state){
        int stateInt = int.Parse(state);
        switch (stateInt)
        {
            case 0:
                RestoreAllSounds();
                break;

            case 1:
                MuteAll();
                break;

            case 2:
                MuteAll();
                break;
        }
     }
 
    private void MuteAll()
    {

    }

    private void RestoreAllSounds()
    {
        musicOn = bool.Parse(PlayerPrefs.GetString("music"));
        soundFxOn = bool.Parse(PlayerPrefs.GetString("soundFx"));
        SetSoundsVolume(musicOn, soundFxOn);
    }

    private void SetSoundsVolume(bool musicToggleOn, bool soundFxToggleOn)
    {
        float fadeTime = 0.1f;
        if (musicToggleOn && soundFxToggleOn) allSoundsOn.TransitionTo(fadeTime);
        if (!musicToggleOn && !soundFxToggleOn) muteAllSounds.TransitionTo(fadeTime);
        if (!musicToggleOn && soundFxToggleOn) muteMusic.TransitionTo(fadeTime);
        if (musicToggleOn && !soundFxToggleOn) muteSoundFx.TransitionTo(fadeTime);
    }

#if UNITY_ANDROID
    public int CheckCallStatus(){
             return jc.CallStatic<int>("getCallStatus");
         }
     #endif
 }