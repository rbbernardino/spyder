using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {

    void Awake()
    {
        Application.runInBackground = false;
    }

    // Use this for initialization
    void Start ()
    {
        int loadedLevel = Application.loadedLevel;
        Application.LoadLevelAsync(loadedLevel + 1);
        //StartCoroutine(GoNextLevel());
    }

    void Update()
    {
        if (!Application.isLoadingLevel)
        {
            StartCoroutine(WaitABit());
        }
    }
    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(0.5f);
    }
/*    IEnumerator GoNextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        int loadedLevel = Application.loadedLevel;
        Application.LoadLevelAsync(loadedLevel + 1);
    }
*/
}
