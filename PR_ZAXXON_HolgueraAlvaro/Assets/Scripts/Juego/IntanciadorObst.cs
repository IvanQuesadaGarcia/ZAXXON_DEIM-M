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
    //Variable con la distancia entre obst�culos
    [SerializeField] float distanciaEntreObstaculos;
    //Variable para las columnas iniciales
    [SerializeField] float distPrimerObst = 60f; //Lo declaro aqu� para poder cambiarlo en Unity

    //Para calcular el intervalo, necesito saber la velocidad
    float speed;

    //Variable que me permitir� acceder al componente con las variables generales
    InitGameScript initGameScript;
    
    void Start()
    {
        //Accedo al componente del Game Object. En este ejemplo, lo hago todo en una sola l�nea
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();

        distanciaEntreObstaculos = 30f;
        intervalo = distanciaEntreObstaculos / initGameScript.spaceshipSpeed;

        //Llamo al m�todo que crea columnas iniciales
        CrearColumnasIniciales();

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
        //Booleana que me dice si ha salido una pared
        bool haSalidoPared = false;
        int contadorParedes = 0;
        //GameObject obstRandom;
        while (true)
        {
            
            
            //Creo el n�mero aleatorio para elegir el prefab del Array
            int randomNum;

            
            //Voctor en el que se instanciar��a
            Vector3 instPos = new Vector3(0f, 0f, initPos.position.z);
            //Obtengo el nivel en el que estamos (en cada vuelta de la corrutina)
            level = initGameScript.levelGame;
            //print(level);
            //Seg�n el nivel, instancio unos u otros obst�culos
            
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

            //Antes de instanciar calculo el intervalo en basde a la velocidad
            intervalo =  distanciaEntreObstaculos / initGameScript.spaceshipSpeed;
            //print(intervalo);

            //Creo un Vector3 que indicar� la posici�n de instanciaci�n
            //El valor X es random, el Z el del objeto de referencia

            if(arrayObst[randomNum].tag == "columna")
            {
                instPos = new Vector3(Random.Range(-20f, 20f), 0f, initPos.position.z);
            }
            else if(arrayObst[randomNum].tag == "pared")
            {
                instPos = new Vector3(0f, 0f, initPos.position.z);
            }
            

            //Instancio el prefab aleatorio en la posici�n calculada
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

    //Este m�todo lo he creado para crear unas columnas iniciales
    void CrearColumnasIniciales()
    {

        //El n� de obst�culos es la resta de d�nde estoy menos el primero, partido por la distancia entre obst�culos
        float numColumnasIniciales = (transform.position.z - distPrimerObst) / distanciaEntreObstaculos;
        //Por si acaso sale un n� con decimales lo redondeo con Mathf.Round
        numColumnasIniciales = Mathf.Round(numColumnasIniciales); //Redondeo el n�mero
        //print("N� de columnas iniciales: " + numColumnasIniciales);
        
        //Creo un bucle pero en vez de sumar 1 lo hago para que me de la posici�n en Z de cada obst�culo
        //la variable n vale al principio la distancia del primer obst�culo
        //Mientras n no llegue a d�nde estoy en Z, seguir� sumando la distancia entre obst�culos
        //De esta forma n es igual a la posici�n en Z donde tengo que instanciar
        for (float n = distPrimerObst; n < transform.position.z; n += distanciaEntreObstaculos)
        {
            //Creo la posici�n de instanciaci�n, con los valores aleatorios y n en la posici�n en Z
            Vector3 initColPos = new Vector3(Random.Range(-10f, 10f), 0f, n);
            //Creo el obst�culo (en mi caso, al ser un array, creo el primero del array
            Instantiate(arrayObst[0], initColPos, Quaternion.identity);

        }
    }
}
