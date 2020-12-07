using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignInAdmin : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;

    public void LoginAdmin()
    {
        var json = JSON.Parse("{\"admin_ID\": " + username.text + ", \"password\": " + password.text + "}");
        var httpRequest = WebRequest.CreateHttp("https://localhost:44389/admin/" + username.text);
        httpRequest.Method = "GET";
        var response = httpRequest.GetResponse();
        var json1 = JSON.Parse((new StreamReader(response.GetResponseStream())).ReadToEnd());
        response.Close();
        Debug.Log(json1["admin_ID"]);
        Debug.Log(json["admin_ID"]);
        Debug.Log(json1["password"]);
        Debug.Log(json["password"]);
        if (json["admin_ID"] == null)
        {
            return;
        }
        if ((json["admin_ID"] == json1["admin_ID"]) && (json["password"] == json1["password"]))
        {
            PlayerPrefs.SetString("admin_ID", json1["admin_ID"]);
            PlayerPrefs.SetString("password", json1["password"]);
            PlayerPrefs.SetString("email", json1["email"]);
            PlayerPrefs.SetString("name",json1["name"]);
            PlayerPrefs.SetString("last_name", json1["last_Name"]);
            PlayerPrefs.SetInt("phone", json1["phone"]);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Admin");
        }
        else
        {
            Debug.Log("User not found");
        }
    }
}
