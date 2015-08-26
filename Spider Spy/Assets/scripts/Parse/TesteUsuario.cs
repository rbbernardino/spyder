using UnityEngine;
using System.Collections;
using Parse;
public class TesteUsuario : MonoBehaviour {


	// Use this for initialization
	void Start () {
        CreateUser();
    }

    void CreateUser()
    {
        var user = new ParseUser()
        {
            Username = "my name",
            Password = "my pass",
            Email = "email@example.com"
        };

        // other fields can be set just like with ParseObject
        user["phone"] = "650-555-0000";

        user.SignUpAsync();


    }


}
