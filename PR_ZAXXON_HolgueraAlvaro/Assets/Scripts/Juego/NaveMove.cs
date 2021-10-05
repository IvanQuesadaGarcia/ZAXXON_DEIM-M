using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{
    //Movimiento de desplazamiento (H/V)
    [SerializeField] float desplSpeed;

    //Variables para la restricción de movimiento (horizontales y verticales)
    float limiteR = 10;
    float limiteL = -10;
    float limiteU = 10;
    float limiteS = 1;

    //Variable booleana que determina si puedo moverme o no
    bool inLimitH = true;
    bool inLimitV = true;



    // Start is called before the first frame update
    void Start()
    {
        //Le asigno un valor a la velocidad de desplazamiento
        desplSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //Lamo a la función que mueve la nave
        MoverNave();


        
        float rot = Input.GetAxis("Horizontal-J2"); //He creado un eje nuevo para la rotación
        //print(rot);
        transform.Rotate(Vector3.back * Time.deltaTime * rot * 100f);

    }

    void MoverNave()
    {
        //Obtengo los valores de los ejes y los asigno a variables
        float desplH = Input.GetAxis("Horizontal");
        float desplV = Input.GetAxis("Vertical");


        //Variables de posición en X y en Y para la restricción
        float posX = transform.position.x;
        float posy = transform.position.y;

        //Restrinjo el movimiento, de momento solo hacia la derecha
        if (posX > limiteR && desplH > 0 || posX < limiteL && desplH < 0)
        {
            inLimitH = false;
        }
        else
        {
            inLimitH = true;
        }

        if (inLimitH)
        {
            transform.Translate(Vector3.right * Time.deltaTime * desplH * desplSpeed, Space.World);
        }


        if (inLimitV)
        {
            transform.Translate(Vector3.up * Time.deltaTime * desplV * desplSpeed, Space.World);
        }

    }
}
