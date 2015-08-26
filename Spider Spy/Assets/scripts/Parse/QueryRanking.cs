using UnityEngine;
using System.Collections;

using Parse;
using System.Collections.Generic;
public class QueryRanking : MonoBehaviour {
    [SerializeField]
    string _name;

    private int positionInRanking;
    // Use this for initialization
    void Start () {
        BuscaRanking();
    }

    void BuscaRanking()
    {
        positionInRanking = 0;
        ParseUser.Query.OrderByDescending("pontuacao").FindAsync().ContinueWith( t =>
        {
            if (t.IsFaulted || t.IsCanceled)
            {
                foreach (var e in t.Exception.InnerExceptions)
                {
                    ParseException parseException = (ParseException)e;
                    Debug.Log("Error message " + parseException.Message);
                    Debug.Log("Error code: " + parseException.Code);
                }

            }
            else
            {
                IEnumerable<ParseUser> users = t.Result;
                foreach (ParseUser user in users)
                {
                    if (user.Username.Equals(_name))
                    {
                        break;
                    }
                    else
                    {
                        positionInRanking++;
                    }
               
                }

                positionInRanking++;

                Debug.Log(positionInRanking);
            }
        });
    }
}
