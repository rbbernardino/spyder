using UnityEngine;
using System.Collections;

public class DestroyBuildingSound : MonoBehaviour {
    [SerializeField] GameObject buildingDestroy1;
    [SerializeField] GameObject buildingDestroy2;

    private AudioSource destroySound1;
    private AudioSource destroySound2;

    // Use this for initialization
    void Start () {
        destroySound1 = buildingDestroy1.GetComponent<AudioSource>();
        destroySound2 = buildingDestroy2.GetComponent<AudioSource>();
    }

    public void StartSounds()
    {
        InvokeRepeating("PlaySound1", 0, 1.126f);
        InvokeRepeating("PlaySound2", 0, 1.126f);
    }

    public void StopSounds()
    {
        destroySound1.Stop();
        destroySound2.Stop();
        CancelInvoke();
    }

    private void PlaySound1() { destroySound1.Play(); }
    private void PlaySound2() { destroySound2.PlayDelayed(0.595f); }
}
