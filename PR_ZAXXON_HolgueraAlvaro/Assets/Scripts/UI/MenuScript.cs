using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{


    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void IniciarHS()
    {
        SceneManager.LoadScene(2);
    }

    public void IniciarConfig()
    {
        SceneManager.LoadScene(3);
    }
}
