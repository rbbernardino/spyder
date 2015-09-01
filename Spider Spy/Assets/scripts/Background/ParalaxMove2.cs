using UnityEngine;
using System.Collections;

public class ParalaxMove2 : MonoBehaviour {
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
        speed = paralaxObjects.GetComponent<ParalaxSettings>().BuildingSet2Speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
    }
}
