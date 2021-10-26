using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameScript : MonoBehaviour
{
    /*---------------------------
    //------VARIABLES GLOBALES
    ------------------------------*/
    public float spaceshipSpeed;

    //Variable que indica el nivel
    public int levelGame;


    // Start is called before the first frame update
    void Start()
    {
        spaceshipSpeed = 30f;
        levelGame = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(spaceshipSpeed > 100)
        {
            
        }
    }

    //Morirse
    public void Morir()
    {
        print("Me he muerto");
        spaceshipSpeed = 0f;
        IntanciadorObst instanciadorObst =  GameObject.Find("InstanciadorObst").GetComponent<IntanciadorObst>();
        instanciadorObst.SendMessage("Parar");
    }
}
