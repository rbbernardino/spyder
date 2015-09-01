using UnityEngine;
using System.Collections;

public class ScrollBuildings : MonoBehaviour {

    private float scrollSpeed;
    public float tileSizeY;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        scrollSpeed = GameObject.FindGameObjectWithTag("GameController").GetComponent<Settings>().BuildingsSpeed;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.down * newPosition;
    }
}
