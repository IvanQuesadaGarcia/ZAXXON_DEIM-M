using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{
    //Movimiento de desplazamiento (H/V)
    [SerializeField] float desplSpeed;

    //Variables para la restricción de movimiento
    float limiteR = 10;
    float limiteL = -10;
    float limiteU = 10;
    float limiteS = 1;


    // Start is called before the first frame update
    void Start()
    {
        //Le asigno un valor a la velocidad de desplazamiento
        desplSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //Obtengo los valores de los ejes y los asigno a variables
        float desplH = Input.GetAxis("Horizontal");
        float desplV = Input.GetAxis("Vertical");
        float rot = Input.GetAxis("Horizontal-J2"); //He creado un eje nuevo para la rotación
        //print(rot);

        //Variables de posición en X y en Y para la restricción
        float posX = transform.position.x;
        float posy = transform.position.y;

        //Restrinjo el movimiento, de momento solo hacia la derecha
        if(posX > limiteR && desplH > 0)
        {
            desplSpeed = 0f;
        }
        else
        {
            desplSpeed = 10f;
        }

        transform.Translate(Vector3.right * Time.deltaTime * desplH * desplSpeed, Space.World);
        transform.Translate(Vector3.up * Time.deltaTime * desplV * desplSpeed, Space.World);
       
        transform.Rotate(Vector3.back * Time.deltaTime * rot * 100f);

    }
}
