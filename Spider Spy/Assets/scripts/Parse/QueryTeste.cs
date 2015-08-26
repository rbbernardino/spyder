using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class QueryTeste : MonoBehaviour {
    [SerializeField] private string field, value;
    ParseUser _user;
     
    // Use this for initialization
    void Start () {
        QueryUserParse();
    }


    void QueryUserParse()
    {
       
            // do stuff with the user
          //  ParseUser.LogOut();
        
        ParseUser.Query.WhereEqualTo(field,value).FindAsync().ContinueWith(t =>
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
                List<ParseUser> totalResultsForQuery = new List<ParseUser>();
                foreach (ParseUser user in users)
                {
                    Debug.Log(user.Username);
                    totalResultsForQuery.Add(user);
                   
                }

                Debug.Log(totalResultsForQuery.Count);
                for (int i = 0; i < totalResultsForQuery.Count; i++)
                {
                    Debug.Log(totalResultsForQuery[i].Username);
                }

            }
        });
    }
}
