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
        positionList[0] = new Vector3(-0.79f, 0.15f, 0);
        positionList[1] = new Vector3(-0.933f, -0.043f, 0);
        positionList[2] = new Vector3(-0.89f, -0.732f, 0);
        positionList[3] = new Vector3(-0.89f, -1.21f, 0);
        positionList[4] = new Vector3(-0.89f, -1.6f, 0);
        positionList[5] = new Vector3(-0.89f, -1.7f, 0);
        positionList[6] = new Vector3(-0.89f, -1.82f, 0);
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
        int itemIndex = Random.Range(0, 3);
        int positionIndex = Random.Range(0, 7);
        Instantiate(crackList[itemIndex], transform.position + positionList[positionIndex], transform.rotation);
    }
}
