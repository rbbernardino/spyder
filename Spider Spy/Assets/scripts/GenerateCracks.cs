using UnityEngine;
using System.Collections;

public class GenerateCracks : MonoBehaviour {

    [SerializeField] GameObject crack1;
    [SerializeField] GameObject crack2;
    [SerializeField] GameObject crack3;

    private GameObject[] crackList = new GameObject[3];
    private Vector3[] positionList = new Vector3[7];

    public float StartTime;
    public float RepeatTime;

    void Start()
    {
        FillCrackList();
        FillPositionList();
    }

    private void FillCrackList()
    {
        crackList[0] = crack1;
        crackList[1] = crack2;
        crackList[2] = crack3;
    }

    private void FillPositionList()
    {
        positionList[0] = new Vector3(-0.999f, 1.463f, 0);
        positionList[1] = new Vector3(-1.008f, 0.624f, 0);
        positionList[2] = new Vector3(-1.115f, 0.224f, 0);
        positionList[3] = new Vector3(-1.027f, -0.312f, 0);
        positionList[4] = new Vector3(-0.988f, -0.663f, 0);
        positionList[5] = new Vector3(-1.183f, -0.001f, 0);
        positionList[6] = new Vector3(-1.28f, 0.574f, 0);
    }

    public void StartCracks()
    {
        InvokeRepeating("CreateCrack", StartTime, RepeatTime);
    }

    public void StopCracks()
    {
        CancelInvoke();
    }

    private void CreateCrack()
    {
        Debug.Log("hum");
        int itemIndex = Random.Range(0, 3);
        int positionIndex = Random.Range(0, 7);
        Instantiate(crackList[itemIndex], transform.position + positionList[positionIndex], transform.rotation);
    }
}
