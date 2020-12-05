using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TMPro;
using UnityEngine;

public class AdminUsers : MonoBehaviour
{
    public TMP_InputField searchUser;
    public TMP_InputField username;
    public TMP_InputField email;
    public TMP_InputField password;

    public void searchForUser()
    {
        var httpRequest = WebRequest.CreateHttp("https://localhost:44389/user/" + searchUser.text);
        httpRequest.Method = "GET";
        var response = httpRequest.GetResponse();
        var json = JSON.Parse((new StreamReader(response.GetResponseStream())).ReadToEnd());
        username.text = json["user_ID"];
        email.text = json["email"];
        password.text = json["password"];

    }
    public void updateUser()
    {
        var json = "{\"user_ID\": \"" + username.text + "\", \"email\": \"" + email.text + "\", \"password\": \"" + password.text + "\"}";
        var httpRequest = WebRequest.CreateHttp("https://localhost:44389/user/" + username.text);
        httpRequest.Method = "PUT";
        httpRequest.ContentType = "application/json";
        var buffer = Encoding.UTF8.GetBytes(json);
        httpRequest.GetRequestStream().Write(buffer, 0, buffer.Length);
        var response = httpRequest.GetResponse();
        username.text = "";
        email.text = "";
        password.text = "";
    }

    public void deleteUser()
    {
        if(username.text.Length == 0)
        {
            return;
        }
        var httpRequest = WebRequest.CreateHttp("https://localhost:44389/user/" + searchUser.text);
        httpRequest.Method = "DELETE";
        var response = httpRequest.GetResponse();
        username.text = "";
        email.text = "";
        password.text = "";
    }
}
