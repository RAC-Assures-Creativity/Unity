using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminData : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField email;
    public TMP_InputField password;

    void Start()
    {
        if (PlayerPrefs.HasKey("user_ID"))
        {
            username.text = PlayerPrefs.GetString("user_ID");
            email.text = PlayerPrefs.GetString("email");
            password.text = PlayerPrefs.GetString("password");
        }
            
    }
}
