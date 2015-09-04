using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {
    public void Play()
    {
        Handheld.PlayFullScreenMovie("ss2.mp4", Color.black, FullScreenMovieControlMode.Full);
        Application.LoadLevel("Main Menu");
    }
}
