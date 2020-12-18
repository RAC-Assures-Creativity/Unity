using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public void CambiarEscena(string nombre)
    {
       print ("Cambiando de escena " + nombre);
       SceneManager.LoadScene(nombre);
    }
	public void salir()
    {
        print ("saliendo");
        Application.Quit();
    }
}
