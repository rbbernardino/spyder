using UnityEngine;
using System.Collections;

public class ParalaxMove : MonoBehaviour {
    public GameObject paralaxObjects;

    private float speed;

    // Use this for initialization
    void Start()
    {
        SetSpeed();
    }

    void Update()
    {
        SetSpeed();
    }

    void SetSpeed()
    {
        speed = paralaxObjects.GetComponent<ParalaxSettings>().BuildingSet1Speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
    }
}
