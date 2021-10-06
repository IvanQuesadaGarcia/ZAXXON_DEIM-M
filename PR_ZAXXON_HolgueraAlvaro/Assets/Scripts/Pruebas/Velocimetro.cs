using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocimetro : MonoBehaviour
{

    //Método para calcular la velocidad de desplazamiento
    bool moving = true;
    //Establezco la velocidad inicial
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        //Pongo al jugador en 0
        transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Obtengo el tiempo transcurrido
        float tt = Time.time;

        //Si la variable moving es true, muevo el objeto
        if(moving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        //Cuando llego al tiempo de 10 segundos, dejo de mover y lanzo un aviso a consola
        if(tt >= 10)
        {
            moving = false;
            float posZ = transform.position.z;
            //Calculo la velocidad a partir del tiempo transcurrido y el espacio recorrido
            //Como han transcurrido 10 segundos, obtengo cuánta distancia será en una hora
            float horas = (posZ * 6 * 60) / 1000; //Paso metros a Kmts
            //Lanzo a pantalla la valocidad obtenida (según la variable speed)
            print("Te mueves a una velocidad de: " + Mathf.Round(horas) + " Kmts/h" );

        }
        else
        {
            //El método Mathf.Round(); redondea una cifra
            print(Mathf.Round(tt));
        }

    }
}
