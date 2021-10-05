using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{

    //Game object con el prefab
    [SerializeField] GameObject ladrillo;
    //Variable Transform de referencia
    [SerializeField] Transform initPos;
    //La separaci�n ser� variable
    float separacion;

    //Numero de filas y de ladrillos por filas
    [SerializeField] int numLadrillos = 10;
    [SerializeField] int numFilas = 5;

    // Start is called before the first frame update
    void Start()
    {

        separacion = 1.1f;

        //Posici�n en Y para las filas
        float desplY = 0f;

        //Las posici�n inicial es la del objeto de referencia
        Vector3 newPos = initPos.position;
        //Creo el Vector que mover� cada instancia
        Vector3 despl = new Vector3(separacion, desplY, 0f);


        //Creo un bucle con las filas
        for (int f = 0; f < numFilas; f++)
        {
            Vector3 fila = new Vector3(0f, desplY, 0f);

            //Bucle para instanciar ladrillos
            for (int n = 0; n < numLadrillos; n++)
            {
                
                Instantiate(ladrillo, newPos, Quaternion.identity);
                newPos = newPos + despl;
            }

            newPos = initPos.position + fila;


            desplY += separacion;
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
