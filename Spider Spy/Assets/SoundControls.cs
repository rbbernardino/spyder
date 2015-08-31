using UnityEngine;
using System.Collections;

public class SoundControls : MonoBehaviour {
    [SerializeField] private GameObject JumpSound;
    [SerializeField] private GameObject BombExplosionSound;
    [SerializeField] private GameObject ItemCatchSound;
    [SerializeField] private GameObject ButtonSound;

	void Start () {
        GetComponent<DestroyBuildingSound>().StartSounds();
    }

    public void PlayJump()             { JumpSound.          GetComponent<AudioSource>().Play(); }
    public void PlayBombExplosion()    { BombExplosionSound. GetComponent<AudioSource>().Play(); }
    public void PlayIntemCatch()       { ItemCatchSound.     GetComponent<AudioSource>().Play(); }
    public void PlayButton()           { ButtonSound.        GetComponent<AudioSource>().Play(); }
    public void PlayClimbingSound()    { GetComponent<DestroyBuildingSound>().StartSounds(); }
    public void StopClimbingSound()    { GetComponent<DestroyBuildingSound>().StopSounds();  }
}
