using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntanciadorObst : MonoBehaviour
{

    //[SerializeField] GameObject obst1; //GameObject que tiene el script
    //[SerializeField] GameObject obst2; //GameObject que tiene el script

    //Posici�n donde se encuentra el Instanciador
    [SerializeField] Transform initPos; 

    //Creo un Array que contendr� los diferentes prefabs con obst�culos
    [SerializeField] GameObject[] arrayObst;
    //Creo una variable que determinar� qu� obst�culos se instanciar�n
    int level;
    //el intervalo para la corrutina, depender� de la velocidad
    float intervalo;

    //Variable que me permitir� acceder al componente con las variables generales
    InitGameScript initGameScript;
    
    void Start()
    {
        //Accedo al componente del Game Object. En este ejemplo, lo hago todo en una sola l�nea
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
        intervalo = 1f; //El intervalo de momento es fijo, ya cambiar�
        //Inicio la Corrutina que instancia los prefabs
        //IMPORTANTE: antes de iniciarla, el intervalo tiene que ser un n�mero v�lido
        StartCoroutine("CrearObstaculos");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Corrutina que instancia prefabs siguiendo los intervalos
    IEnumerator CrearObstaculos()
    {
        //GameObject obstRandom;
        while (true)
        {
            //Creo un Vector3 que indicar� la posici�n de instanciaci�n
            //El valor X es random, el Z el del objeto de referencia
            Vector3 instPos = new Vector3(Random.Range(-10f, 10f), 0f, initPos.position.z);
            
            //Creo el n�mero aleatorio para elegir el prefab del Array
            int randomNum;
            //Obtengo el nivel en el que estamos (en cada vuelta de la corrutina)
            level = initGameScript.levelGame;
            //print(level);
            //Seg�n el nivel, instancio unos u otros obst�culos
            if (level == 0)
            {
                randomNum = 0;
            }
            else if(level > 0 && level < 4)
            {
                randomNum = Random.Range(0, 5);
            }
            else
            {
                //En este caso, el n� aleatorio es entre 0 y la longitud del Array
                randomNum = Random.Range(0, arrayObst.Length);
            }
            
            /*
            //M�todo alternativo y b�sico, sin usar Array
            if(randomNum == 1)
            {
                obstRandom = obst1;
            }
            else
            {
                obstRandom = obst2;
            }
            */
            //Instancio el prefab aleatorio en la posici�n calculada
            Instantiate(arrayObst[randomNum], instPos, Quaternion.identity);

            yield return new WaitForSeconds(intervalo);

        }
    }
}
