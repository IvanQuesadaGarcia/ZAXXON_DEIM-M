using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrenoMove : MonoBehaviour
{
    //Velocidad de movimiento que cogeremos de InitGame
    float speed;
    //Para acceder a las variables generales
    InitGameScript initGameScript;

    //Prefab del terreno
    [SerializeField] GameObject terrenoPrefab;
    //Posición en la que se instanciará (depende de su tamaño)
    Vector3 instPos = new Vector3(0f, 0f, 200f);
    // Start is called before the first frame update
    void Start()
    {
        initGameScript = GameObject.Find("InitGame").GetComponent<InitGameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Obtengo la velocidad
        speed = initGameScript.spaceshipSpeed;
        //El terreno se mueve
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        //Cuando llego a -100 en Z instancio otro terreno y me destruyo
        if(transform.position.z <= -100)
        {
            Instantiate(terrenoPrefab, instPos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
