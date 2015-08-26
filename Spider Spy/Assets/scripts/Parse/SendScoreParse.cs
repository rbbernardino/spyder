using UnityEngine;
using System.Collections;
using Parse;

public class SendScoreParse : MonoBehaviour {
	private string _nome,_pwd;
    [SerializeField]
    int _newScore;

	// Use this for initialization
	void Start () {
		StartCoroutine( CheckLogin ());
    }


	IEnumerator CheckLogin()
	{	
		if (GetComponent<Login> ().user != null) {
			_nome = GetComponent<Login>().user.Username;
			_pwd = GetComponent<Login>().getPwd();
            AttDataParse(_newScore);
        } else {
			GetComponent<Login>().loginInParse();
            yield return new WaitForSeconds(1.0f);
            StartCoroutine( CheckLogin());
		}
	}

	public  void AttDataParse(int entrada)
	{
		
		ParseUser.LogInAsync(_nome, _pwd).ContinueWith(t =>
		                                             {
			if (t.IsFaulted || t.IsCanceled)
			{
				Debug.Log("Login Fail");
			}
			else
			{
				ParseUser user;
				// Login was successful
				user = t.Result;
				user["score"] = entrada.ToString();
				user.SaveAsync();
                Debug.Log("att Parse");
			}
		});
	}
	

}
