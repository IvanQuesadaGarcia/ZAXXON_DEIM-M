using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntanciadorObst : MonoBehaviour
{

    //[SerializeField] GameObject obst1; //GameObject que tiene el script
    //[SerializeField] GameObject obst2; //GameObject que tiene el script

    //Posición donde se encuentra el Instanciador
    [SerializeField] Transform initPos; 

    //Creo un Array que contendrá los diferentes prefabs con obstáculos
    [SerializeField] GameObject[] arrayObst;



    //Creo una variable que determinará qué obstáculos se instanciarán
    int level;
    //el intervalo para la corrutina, dependerá de la velocidad
    float intervalo;
    //Variable con la distancia entre obstáculos
    [SerializeField] float distanciaEntreObstaculos;
    //Variable para las columnas iniciales
    [SerializeField] float distPrimerObst = 60f; //Lo declaro aquí para poder cambiarlo en Unity

    //Para calcular el intervalo, necesito saber la velocidad
    float speed;

    //Variable que me permitirá acceder al componente con las variables generales
    InitGameScript initGameScript;
    
    void Start()
    {
        //Accedo al componente del Game Object. En este ejemplo, lo hago todo en una sola línea
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();

        distanciaEntreObstaculos = 30f;
        intervalo = distanciaEntreObstaculos / initGameScript.spaceshipSpeed;

        //Llamo al método que crea columnas iniciales
        CrearColumnasIniciales();

        //Inicio la Corrutina que instancia los prefabs
        //IMPORTANTE: antes de iniciarla, el intervalo tiene que ser un número válido
        StartCoroutine("CrearObstaculos");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Corrutina que instancia prefabs siguiendo los intervalos
    IEnumerator CrearObstaculos()
    {
        //Booleana que me dice si ha salido una pared
        bool haSalidoPared = false;
        int contadorParedes = 0;
        //GameObject obstRandom;
        while (true)
        {
            
            
            //Creo el número aleatorio para elegir el prefab del Array
            int randomNum;

            
            //Voctor en el que se instanciar´´a
            Vector3 instPos = new Vector3(0f, 0f, initPos.position.z);
            //Obtengo el nivel en el que estamos (en cada vuelta de la corrutina)
            level = initGameScript.levelGame;
            //print(level);
            //Según el nivel, instancio unos u otros obstáculos
            
            if (level == 0)
            {
                randomNum = 0;
            }
            else if(level > 0 && level < 4 || haSalidoPared == true)
            {
                randomNum = Random.Range(0, 2);
            }
            else
            {
                //En este caso, el nº aleatorio es entre 0 y la longitud del Array
                randomNum = Random.Range(0, arrayObst.Length);
            }

            /*
            //Método alternativo y básico, sin usar Array
            if(randomNum == 1)
            {
                obstRandom = obst1;
            }
            else
            {
                obstRandom = obst2;
            }
            */

            //Antes de instanciar calculo el intervalo en basde a la velocidad
            intervalo =  distanciaEntreObstaculos / initGameScript.spaceshipSpeed;
            //print(intervalo);

            //Creo un Vector3 que indicará la posición de instanciación
            //El valor X es random, el Z el del objeto de referencia

            if(arrayObst[randomNum].tag == "columna")
            {
                instPos = new Vector3(Random.Range(-20f, 20f), 0f, initPos.position.z);
            }
            else if(arrayObst[randomNum].tag == "pared")
            {
                instPos = new Vector3(0f, 0f, initPos.position.z);
            }
            

            //Instancio el prefab aleatorio en la posición calculada
            Instantiate(arrayObst[randomNum], instPos, Quaternion.identity);


            print(arrayObst[randomNum].tag);
            if(arrayObst[randomNum].tag == "pared")
            {
                haSalidoPared = true;
            }

            if(haSalidoPared)
            {
                contadorParedes++;
            }
            if(contadorParedes == 5)
            {
                haSalidoPared = false;
                contadorParedes = 0;
            }
           


            yield return new WaitForSeconds(intervalo);

        }
    }

    //Este método lo he creado para crear unas columnas iniciales
    void CrearColumnasIniciales()
    {

        //El nº de obstáculos es la resta de dónde estoy menos el primero, partido por la distancia entre obstáculos
        float numColumnasIniciales = (transform.position.z - distPrimerObst) / distanciaEntreObstaculos;
        //Por si acaso sale un nº con decimales lo redondeo con Mathf.Round
        numColumnasIniciales = Mathf.Round(numColumnasIniciales); //Redondeo el número
        //print("Nº de columnas iniciales: " + numColumnasIniciales);
        
        //Creo un bucle pero en vez de sumar 1 lo hago para que me de la posición en Z de cada obstáculo
        //la variable n vale al principio la distancia del primer obstáculo
        //Mientras n no llegue a dónde estoy en Z, seguirá sumando la distancia entre obstáculos
        //De esta forma n es igual a la posición en Z donde tengo que instanciar
        for (float n = distPrimerObst; n < transform.position.z; n += distanciaEntreObstaculos)
        {
            //Creo la posición de instanciación, con los valores aleatorios y n en la posición en Z
            Vector3 initColPos = new Vector3(Random.Range(-10f, 10f), 0f, n);
            //Creo el obstáculo (en mi caso, al ser un array, creo el primero del array
            Instantiate(arrayObst[0], initColPos, Quaternion.identity);

        }
    }
}
