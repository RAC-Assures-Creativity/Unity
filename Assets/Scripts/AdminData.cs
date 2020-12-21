using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminData : MonoBehaviour
{
    public TMP_InputField admin_id;
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_InputField nameAdmin;
    public TMP_InputField last_name;
    public TMP_InputField phone;
    public GameObject confirm;

    void Start()
    {
        if (PlayerPrefs.HasKey("admin_ID"))
        {
            admin_id.text = PlayerPrefs.GetString("admin_ID");
            email.text = PlayerPrefs.GetString("password");
            password.text = PlayerPrefs.GetString("email");
            nameAdmin.text =PlayerPrefs.GetString("name");
            last_name.text = PlayerPrefs.GetString("last_name");
            phone.text = PlayerPrefs.GetInt("phone").ToString();
        }
            
    }

    public void updateAdmin()
    {
        var number = Int32.Parse(phone.text);
        var json = "{\"admin_ID\": \"" + admin_id.text + "\", \"email\": \"" + email.text + "\", \"password\": \"" + password.text + "\", \"name\": \"" + nameAdmin.text + "\", \"last_Name\": \"" + last_name.text + "\", \"phone\": " + number  + "}";
        var httpRequest = WebRequest.CreateHttp("https://localhost:44389/admin/" + admin_id.text);
        httpRequest.Method = "PUT";
        httpRequest.ContentType = "application/json";
        var buffer = Encoding.UTF8.GetBytes(json);
        httpRequest.GetRequestStream().Write(buffer, 0, buffer.Length);
        var response = httpRequest.GetResponse();
        response.Close();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("admin_ID", admin_id.text);
        PlayerPrefs.SetString("password", password.text);
        PlayerPrefs.SetString("email", email.text);
        PlayerPrefs.SetString("name", nameAdmin.text);
        PlayerPrefs.SetString("last_name", last_name.text);
        PlayerPrefs.SetInt("phone", Int32.Parse(phone.text));
        PlayerPrefs.Save();
        confirm.SetActive(true);
        Invoke("RemoveConfirm", 2.0f);
    }

    public void RemoveConfirm()
    {
        confirm.SetActive(false);
    }
}
