using UnityEngine;
using System.Collections;

public class SoundControls : MonoBehaviour {
    [SerializeField] private GameObject JumpSound;
    [SerializeField] private GameObject BombExplosionSound;
    [SerializeField] private GameObject ItemCatchSound;
    [SerializeField] private GameObject ButtonSound;
    [SerializeField] private GameObject BuildingDigSound;
    [SerializeField] private GameObject SpyClimbSound;

	// Use this for initialization
	void Start () {
	
	}

    public void PlayJump()             { JumpSound.          GetComponent<AudioSource>().Play(); }
    public void PlayBombExplosion()    { BombExplosionSound. GetComponent<AudioSource>().Play(); }
    public void PlayIntemCatch()       { ItemCatchSound.     GetComponent<AudioSource>().Play(); }
    public void PlayButton()           { ButtonSound.        GetComponent<AudioSource>().Play(); }

    public void PlayClimbingSound()
    {
        BuildingDigSound.   GetComponent<AudioSource>().Play();
        SpyClimbSound.      GetComponent<AudioSource>().Play();
    }

    public void StopClimbingSound()
    {
        BuildingDigSound.GetComponent<AudioSource>().Stop();
        SpyClimbSound.GetComponent<AudioSource>().Stop();
    }
}
