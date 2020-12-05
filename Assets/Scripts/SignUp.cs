using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleJSON;
using System.Net;
using UnityEngine.SceneManagement;
using System.Text;

public class SignUp : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_InputField passwordConfirm;

    public void Register()
    {
        if (password.text != passwordConfirm.text)
        {
            Debug.Log("Password diferente");
            return;
        }
        if (!email.text.Contains("@"))
        {
            Debug.Log("El email no tiene @");
            return;
        }
        //TODO Verificar que no existan id doble por favor
        var json = "{\"user_ID\": \"" + username.text + "\", \"email\": \"" + email.text + "\", \"password\": \"" + password.text + "\"}";
        var httpRequest = WebRequest.CreateHttp("https://localhost:44389/user");
        httpRequest.Method = "POST";
        httpRequest.ContentType = "application/json";
        var buffer = Encoding.UTF8.GetBytes(json);
        httpRequest.GetRequestStream().Write(buffer, 0, buffer.Length);
        Debug.Log(json);
        Debug.Log(httpRequest.GetResponse());
        //SceneManager.LoadScene("SelectionScenes");
    }
}
