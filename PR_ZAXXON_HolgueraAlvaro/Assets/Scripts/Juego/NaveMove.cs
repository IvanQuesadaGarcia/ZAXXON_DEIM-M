using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{
    //Movimiento de desplazamiento (H/V)
    [SerializeField] float desplSpeed;

    [SerializeField] GameObject navePrefab;

    //Variables para la restricción de movimiento (horizontales y verticales)
    float limiteR = 10;
    float limiteL = -10;
    float limiteU = 10;
    float limiteS = 1;

    //Variable booleana que determina si puedo moverme o no
    bool inLimitH = true;
    bool inLimitV = true;

    //
    InitGameScript initGameScript;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 2.3f, 0f);
        //Le asigno un valor a la velocidad de desplazamiento
        desplSpeed = 10f;

        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
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
        float posY = transform.position.y;

        //Restrinjo el movimiento, de momento solo hacia la derecha
        if (posX > limiteR && desplH > 0 || posX < limiteL && desplH < 0)
        {
            inLimitH = false;
        }
        else
        {
            inLimitH = true;
        }

        if (posY > limiteU && desplV > 0 || posY < limiteS && desplV < 0)
        {
            inLimitV = false;
        }
        else
        {
            inLimitV = true;
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

    private void OnTriggerEnter(Collider other)
    {
        print("Ostia");
        if(other.gameObject.layer == 6)
        {

            //initGameScript.SendMessage("Morir");
            navePrefab.SetActive(false);
            //Destroy(gameObject);
            
        }
    }
}
