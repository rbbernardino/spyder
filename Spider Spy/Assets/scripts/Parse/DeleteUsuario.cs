using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class DeleteUsuario : MonoBehaviour {
    [SerializeField]
    private string nome, pwd;
    // Use this for initialization
    void Start () {
        ParseUser user;
        //   ParseUser.LogOut();
        ParseUser.LogInAsync(nome, pwd).ContinueWith(t =>
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
                // Login was successful

                user = t.Result;
                Debug.Log(user.Username);
                user.DeleteAsync();
                ParseUser.LogOut();
                
            }
        });
    }
	

}
