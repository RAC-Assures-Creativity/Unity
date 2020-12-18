using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class ControladorMultiplayer : NetworkBehaviour
{
    public void CambiarEscena(string nombre)
    {
        print("Cambiando de escena " + nombre);
        SceneManager.LoadScene(nombre);
    }
    public void salir()
    {
        print("saliendo");
        Application.Quit();
    }
}