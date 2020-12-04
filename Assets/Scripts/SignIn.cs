using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleJSON;
using System.Net;
using System.IO;
using UnityEngine.SceneManagement;

public class SignIn : MonoBehaviour
{

    public TMP_InputField username;
    public TMP_InputField password;

    public void Login()
    {
        var json = JSON.Parse("{\"user_ID\": " + username.text + ", \"password\": "+ password.text + "}");
        var httpRequest = WebRequest.CreateHttp("https://localhost:44389/user/" + username.text);
        httpRequest.Method = "GET";
        var response = httpRequest.GetResponse();
        var json1 = JSON.Parse((new StreamReader(response.GetResponseStream())).ReadToEnd());
        Debug.Log("User J:" + json["user_ID"]);
        Debug.Log("Password J:" + json["password"]);
        Debug.Log("User J1:" + json1["user_ID"]);
        Debug.Log("Password J1:" + json1["password"]);
        if ((json["user_ID"] == json1["user_ID"]) && (json["password"] == json1["password"]))
        {
            SceneManager.LoadScene("SelectionScenes");
        } else
        {
            Debug.Log("User not found");
        }
    }
}
