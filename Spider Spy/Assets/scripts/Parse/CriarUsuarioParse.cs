using UnityEngine;
using System.Collections;
using Parse;

public class CriarUsuarioParse : MonoBehaviour {

	[SerializeField] private string usuario = "", pwd = "", email = "";
	[SerializeField] private int scoreInicial = 0;
	// Use this for initialization
	void Start () {
        CreateUser();
    }

    void CreateUser()
	{
		ParseUser.LogOut();
        var user = new ParseUser(){
            Username = usuario,
            Password = pwd,
            Email = email
        };

        // other fields can be set just like with ParseObject
        user["pontuacao"] = (int) scoreInicial;

        user.SignUpAsync().ContinueWith( t => {
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
				//SignUpAsync(); //DONE
                Debug.Log("Usuário criado com sucesso");
            }
        }); 
        
		ParseUser.LogOut();
		
	}
}
