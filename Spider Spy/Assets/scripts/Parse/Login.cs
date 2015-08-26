using UnityEngine;
using System.Collections;
using Parse;

public class Login : MonoBehaviour {
    public ParseUser user;
    [SerializeField]
    string nome, pwd;
  
    // Use this for initialization
    void OnEnable () {
        user = null;
       
        loginInParse();
	
	}

  public  void loginInParse()
    {
        
        ParseUser.LogInAsync(nome, pwd).ContinueWith(t =>
        {
            if (t.IsFaulted || t.IsCanceled)
        {
            Debug.Log("Login Fail");
        }
        else
        {
            // Login was successful
            user = t.Result;
                Debug.Log(user.Username);
//                string email;
//                user.TryGetValue<string>("score", out email);
//            Debug.Log(email );
            }
        });
    }

	public string getPwd()
	{ return pwd;}
}
